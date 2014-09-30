using Antelope.Models;
using Antelope.Models.HSE;
using Antelope.Models.Socle;
using Antelope.Repositories.HSE;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Threading;
using Antelope.Repositories.Socle;

namespace Antelope.Controllers.API.HSE
{
    public class FicheSecuriteController : ApiController
    {

        public FicheSecuriteRepository _ficheSecuriteRepository { get; set; }
        public PersonneRepository _personneRepository { get; set; }
        private AntelopeContext db = new AntelopeContext();

        public FicheSecuriteController() {

            _ficheSecuriteRepository = new FicheSecuriteRepository();
            _personneRepository = new PersonneRepository();
        }
        
        // GET api/fichesecuriteapi
        public HttpResponseMessage Get()
        {
            var ficheSecurites = _ficheSecuriteRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, ficheSecurites);
        }

        // GET api/fichesecuriteapi/5
        public HttpResponseMessage Get(int id)
        {

            FicheSecurite ficheSecurite;
            List<Zone> AllZone;
            List<Lieu> AllLieu;
            List<Service> AllService;
            List<PosteDeTravail> AllPosteDeTravail;

            // Si l'ID = -1 >> Nouvelle Fiche

            if (id == -1)
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "refresco.local"); //"refresco.local" > Pas obligatoire ?
                UserPrincipal user = UserPrincipal.Current;
                DirectoryEntry de = user.GetUnderlyingObject() as DirectoryEntry;
                String userCompanyName = (String)de.Properties["company"].Value;

                var querySiteUser = from s in db.Sites
                                    where s.Trigramme == userCompanyName
                                    select s;
                Site SiteUser = (Site)querySiteUser.SingleOrDefault();

                ficheSecurite = new FicheSecurite()
                {
                    SiteId = SiteUser.SiteID,
                    WorkFlowDiffusee = false,
                    WorkFlowAttenteASEValidation = false,
                    WorkFlowASEValidee = false,
                    WorkFlowASERejetee = false,
                    WorkFlowCloturee = false
                };

                var queryZone = from a in db.Zones
                                where a.SiteId == SiteUser.SiteID
                                select a;
                AllZone = queryZone.ToList();

                AllLieu = new List<Lieu>();

                var queryService = from a in db.Services
                                   where a.SiteId == SiteUser.SiteID
                                   select a;
                AllService = queryService.ToList();

                AllPosteDeTravail = new List<PosteDeTravail>();


            }
            // Si l'ID != -1 >> Fiche existante
            else
            {

                ficheSecurite = _ficheSecuriteRepository.Get(id);

                if (ficheSecurite == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                var queryZone = from a in db.Zones
                                where a.SiteId == ficheSecurite.SiteId
                                select a;
                AllZone = queryZone.ToList();

                var queryLieu = from a in db.Lieux
                                where a.ZoneId == ficheSecurite.ZoneId
                                select a;
                AllLieu = queryLieu.ToList();

                var queryService = from a in db.Services
                                   where a.SiteId == ficheSecurite.SiteId
                                   select a;
                AllService = queryService.ToList();

                var queryPosteDeTravail = from a in db.PosteDeTravails
                                          where a.ZoneId == ficheSecurite.ZoneId
                                          select a;
                AllPosteDeTravail = queryPosteDeTravail.ToList();

            }



            var ficheSecuriteViewModel = new FicheSecuriteViewModel(ficheSecurite, AllZone, AllLieu, AllService, AllPosteDeTravail);
            return Request.CreateResponse(HttpStatusCode.OK, ficheSecuriteViewModel);
        }

        private static void SendMailThread(MailMessage mail, SmtpClient smtp)
        {

            smtp.Send(mail);
            
        }

        // POST api/fichesecuriteapi
        public HttpResponseMessage Post(FicheSecurite FicheSecurite)
        {

            var context = new PrincipalContext(ContextType.Domain, "refresco.local"); //"refresco.local" > Pas obligatoire ?
            //define a "query-by-example" principal - here, we search for a UserPrincipal 
            //and with the first name (GivenName) and a last name (Surname) 
            UserPrincipal qbeUser = new UserPrincipal(context);

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("Sezar@refresco.fr");
            mail.Subject = "Alerte Sécurité !!!";
            mail.Body = "Nouveau message d'alerte sécurité";
            mail.To.Add("jucok@gmx.fr");
            mail.To.Add("julien.cokelaere@refresco.fr");
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "dlf-sk8vm03.refresco.local";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = true; // si false, décommenter la ligne de dessous
            //smtp.Credentials = new System.Net.NetworkCredential("username", "password"); // Renseigner le nom d'utilisateur et le mot de passe
            smtp.EnableSsl = false;

            //On crée un nouveau Thread, afin de ne pas attendre l'authentification serveur Exchange pour envoyer le mail.
            Thread T1 = new Thread(delegate()
            {                
                smtp.Send(mail);   
            });
            T1.Start();

            FicheSecurite.DateCreation = DateTime.Now;

            Personne responsable;
            Personne personneConcernee;

            //TODO : REFACTOR CETTE PARTIE : Très vite
            if (FicheSecurite.ResponsableId == null)
            {
                responsable = _personneRepository.GetPersonneByNomPrenom(FicheSecurite.Responsable.Nom, FicheSecurite.Responsable.Prenom);
                if (responsable == null)
                {
                    qbeUser.GivenName = FicheSecurite.Responsable.Prenom;
                    qbeUser.Surname = FicheSecurite.Responsable.Nom;

                    PrincipalSearcher srch = new PrincipalSearcher(qbeUser);
                    Principal principal = srch.FindOne();

                    if (principal == null)
                    {
                        responsable = new Personne()
                        {
                            Nom = FicheSecurite.Responsable.Nom,
                            Prenom = FicheSecurite.Responsable.Prenom
                        };
                    }
                    else
                    {
                        var utilisateurAD = principal.GetUnderlyingObject() as DirectoryEntry;
                        responsable = new Personne()
                        {
                            Nom = (string)utilisateurAD.Properties["sn"].Value,
                            Prenom = (string)utilisateurAD.Properties["givenName"].Value,
                            Guid = (Guid)principal.Guid
                        };

                    }
                }

            }
            else{
                var queryResponsable = from p in db.Personnes
                                    where p.PersonneId == FicheSecurite.ResponsableId
                                    select p;
                responsable = queryResponsable.SingleOrDefault();
            }


            if (FicheSecurite.PersonneConcerneeId == null)
            {
                var queryPersonne = from p in db.Personnes
                                    where p.Nom == FicheSecurite.PersonneConcernee.Nom
                                    && p.Prenom == FicheSecurite.PersonneConcernee.Prenom 
                                    select p;
                personneConcernee = queryPersonne.SingleOrDefault();
                if (personneConcernee == null)
                {
                    qbeUser.GivenName = FicheSecurite.PersonneConcernee.Prenom;
                    qbeUser.Surname = FicheSecurite.PersonneConcernee.Nom;

                    PrincipalSearcher srch = new PrincipalSearcher(qbeUser);
                    Principal principal = srch.FindOne();

                    if (principal == null)
                    {
                        personneConcernee = new Personne()
                        {
                            Nom = FicheSecurite.PersonneConcernee.Nom,
                            Prenom = FicheSecurite.PersonneConcernee.Prenom
                        };
                    }
                    else
                    {
                        var utilisateurAD = principal.GetUnderlyingObject() as DirectoryEntry;
                        personneConcernee = new Personne()
                        {
                            Nom = (string)utilisateurAD.Properties["sn"].Value,
                            Prenom = (string)utilisateurAD.Properties["givenName"].Value,
                            Guid = (Guid)principal.Guid
                        };

                    }
                }
            }
            else{
                var queryPersonneConcernee = from p in db.Personnes
                                        where p.PersonneId == FicheSecurite.PersonneConcerneeId
                                        select p;
                personneConcernee = queryPersonneConcernee.SingleOrDefault();
            }

            // TODO : End du refactor tres vite

            FicheSecurite.Responsable = responsable;
            FicheSecurite.PersonneConcernee = personneConcernee;

            FicheSecurite.WorkFlowDiffusee = true;

            db.FicheSecurites.Add(FicheSecurite);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, FicheSecurite);


        }

        [AcceptVerbs("PUT")]
        public HttpResponseMessage ChangeWorkFlowEtat(Int32 id, string param1)
        {

            FicheSecurite FicheSecurite = _ficheSecuriteRepository.Get(id);

            switch (param1)
            {
                case "AttenteASEValidation":
                    FicheSecurite.WorkFlowASEValidee = false;
                    FicheSecurite.WorkFlowASERejetee = false;
                    FicheSecurite.WorkFlowAttenteASEValidation = true;
                break;
                case "ASEValidee":
                    FicheSecurite.WorkFlowAttenteASEValidation = false;
                    FicheSecurite.WorkFlowASEValidee = true;
                    FicheSecurite.WorkFlowASERejetee = false;
                break;
                case "ASERejetee":
                    FicheSecurite.WorkFlowAttenteASEValidation = false;
                    FicheSecurite.WorkFlowASEValidee = false;
                    FicheSecurite.WorkFlowASERejetee = true;
                break;
            } 

            _ficheSecuriteRepository._db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, FicheSecurite);
        }

        // PUT api/fichesecuriteapi/5
        public HttpResponseMessage Put(int id, FicheSecurite ficheSecurite/* [FromBody]string value */)
        {


            db.Entry(ficheSecurite).State = EntityState.Modified;

       
                db.SaveChanges();


            return Request.CreateResponse(HttpStatusCode.OK);


        }

        // DELETE api/fichesecuriteapi/5
        public void Delete(int id)
        {
        }
    }
}

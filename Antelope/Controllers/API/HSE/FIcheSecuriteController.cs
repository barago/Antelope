using Antelope.Domain.Models;
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
using Antelope.DTOs.Socle;
using Antelope.Services.Socle;
using Antelope.Services.HSE;
using Antelope.Infrastructure.EntityFramework;

namespace Antelope.Controllers.API.HSE
{
    public class FicheSecuriteController : ApiController
    {

        public FicheSecuriteRepository _ficheSecuriteRepository { get; set; }
        public PersonneRepository _personneRepository { get; set; }
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }
        private PersonneAnnuaireService _personneAnnuaireService { get; set; }
        private EmailService _emailService { get; set; }
        private AntelopeEntities db = new AntelopeEntities();
        public ActiveDirectoryService _activeDirectoryService { get; set; }

        public FicheSecuriteController() {

            _ficheSecuriteRepository = new FicheSecuriteRepository();
            _personneRepository = new PersonneRepository();
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
            _personneAnnuaireService = new PersonneAnnuaireService();
            _emailService = new EmailService();
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

            _activeDirectoryService = new ActiveDirectoryService();

            FicheSecurite ficheSecurite;
            List<Zone> AllZone;
            List<Lieu> AllLieu;
            List<Service> AllService;
            List<PosteDeTravail> AllPosteDeTravail;

            // Si l'ID = -1 >> Nouvelle Fiche

            if (id == -1)
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "refresco.local"); //"refresco.local" > Pas obligatoire ?
                //UserPrincipal user = UserPrincipal.Current;
                UserPrincipal user = _activeDirectoryService.GetActiveDirectoryUser(System.Web.HttpContext.Current.User.Identity.Name.Split('\\')[1]);

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

            _emailService.SendEmailDiffusionFicheSecurite();

            FicheSecurite.DateCreation = DateTime.Now;

            FicheSecurite.Responsable = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                FicheSecurite.Responsable.Nom, FicheSecurite.Responsable.Prenom, FicheSecurite.ResponsableId
                );
            FicheSecurite.PersonneConcernee = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                FicheSecurite.PersonneConcernee.Nom, FicheSecurite.PersonneConcernee.Prenom, FicheSecurite.PersonneConcerneeId
                ); ;

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

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

namespace Antelope.Controllers.API.HSE
{
    public class FicheSecuriteController : ApiController
    {
        
        public FicheSecuriteRepository _ficheSecuriteRepository {get; set;}
        private AntelopeContext db = new AntelopeContext();

        public FicheSecuriteController() {

            _ficheSecuriteRepository = new FicheSecuriteRepository();
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

            var ficheSecurite = (id == -1) ? new FicheSecurite() : _ficheSecuriteRepository.Get(id);
            if (ficheSecurite == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var queryZone = from a in db.Zones
                            where a.SiteId == ficheSecurite.SiteId
                            select a;
            List<Zone> AllZone = queryZone.ToList();

            var queryLieu = from a in db.Lieux
                            where a.ZoneId == ficheSecurite.ZoneId
                            select a;
            List<Lieu> AllLieu = queryLieu.ToList();

            var queryService = from a in db.Services
                            where a.SiteId == ficheSecurite.SiteId
                            select a;
            List<Service> AllService = queryService.ToList();

            var queryPosteDeTravail = from a in db.PosteDeTravails
                            where a.ZoneId == ficheSecurite.ZoneId
                            select a;
            List<PosteDeTravail> AllPosteDeTravail = queryPosteDeTravail.ToList();

            var ficheSecuriteViewModel = new FicheSecuriteViewModel(ficheSecurite, AllZone, AllLieu, AllService, AllPosteDeTravail);
            return Request.CreateResponse(HttpStatusCode.OK, ficheSecuriteViewModel);
        }


        // POST api/fichesecuriteapi
        public HttpResponseMessage Post(FicheSecurite FicheSecurite)
        {

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
            smtp.Send(mail);

            FicheSecurite.DateCreation = DateTime.Now;
            FicheSecurite.DateEvenement = DateTime.Now;

            FicheSecurite.WorkFlowDiffusee = true;

            db.FicheSecurites.Add(FicheSecurite);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);


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

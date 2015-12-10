using Antelope.Repositories.HSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;
using Antelope.ViewModels.Socle.DataTables;
using Antelope.Domain.Models;
using System.Net;
using System.Web.Http.Description;
using Antelope.Repositories.Socle;
using Antelope.ViewModels.HSE.DialogueSecuriteViewModels;
using Antelope.Infrastructure.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Antelope.Controllers.API.HSE
{
    public class DialogueSecuriteController : ApiController
    {

        public DialogueSecuriteRepository _dialogueSecuriteRepository { get; set; }
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }
        private AntelopeEntities db = new AntelopeEntities();

        public HttpResponseMessage Get()
        {

            _dialogueSecuriteRepository = new DialogueSecuriteRepository();

            Dictionary<string, string> DataTableParameters = new Dictionary<string, string>();
            DataTableParameters = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            DataTableViewModel<DialogueSecurite> DataTableViewModel = _dialogueSecuriteRepository.GetFromParams(DataTableParameters);

            return Request.CreateResponse(HttpStatusCode.OK, DataTableViewModel);
        }


        [ResponseType(typeof(DialogueSecurite))]
        public HttpResponseMessage Get(int id)
        {
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
            _dialogueSecuriteRepository = new DialogueSecuriteRepository();

            DialogueSecurite DialogueSecurite;
            List<Zone> AllZone;
            List<Lieu> AllLieu;

            if (id == -1)
            {
                Site SiteUser = _activeDirectoryUtilisateurRepository.GetCurrentUserSite();

                DialogueSecurite = new DialogueSecurite()
                {
                    SiteId = (SiteUser == null) ? 0 : SiteUser.SiteID
                };

                var queryZone = from a in db.Zones
                                where a.SiteId == SiteUser.SiteID
                                select a;
                AllZone = queryZone.ToList();

                AllLieu = new List<Lieu>();


            }
            else
            {
                DialogueSecurite = _dialogueSecuriteRepository.Get(id);

                if (DialogueSecurite == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                var queryZone = from a in db.Zones
                                where a.SiteId == DialogueSecurite.SiteId
                                select a;
                AllZone = queryZone.ToList();

                var queryLieu = from a in db.Lieux
                                where a.ZoneId == DialogueSecurite.ZoneId
                                orderby a.Rang
                                select a;
                AllLieu = queryLieu.ToList();
            }

            var DialogueSecuriteViewModel = new DialogueSecuriteViewModel(DialogueSecurite, AllZone, AllLieu);
            return Request.CreateResponse(HttpStatusCode.OK, DialogueSecuriteViewModel);
        }

        [ResponseType(typeof(void))]
        public HttpResponseMessage Put(int id, DialogueSecurite dialogueSecurite)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != dialogueSecurite.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


            var currentdialogueSecurite = db.DialogueSecurites.Find(dialogueSecurite.Id);
            db.Entry(dialogueSecurite).CurrentValues.SetValues(dialogueSecurite);

            db.Entry(currentdialogueSecurite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DialogueSecuriteExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, currentdialogueSecurite);
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, currentdialogueSecurite);
        }

        [ResponseType(typeof(NonConformite))]
        public HttpResponseMessage Post(DialogueSecurite dialogueSecurite)
        {
           // DialogueSecurite.DateCreation = DateTime.Now;

            dialogueSecurite.CompteurAnnuelSite = 1;

            var QueryLastDialogueSecuriteForSiteAnnee = from ds in db.DialogueSecurites
                                                        where ds.SiteId == dialogueSecurite.SiteId
                                                     && ds.Date.Year == dialogueSecurite.Date.Year
                                                     orderby ds.CompteurAnnuelSite descending
                                                     select ds;

            DialogueSecurite LastDialogueSecuriteForSiteAnnee = QueryLastDialogueSecuriteForSiteAnnee.FirstOrDefault();

            if (LastDialogueSecuriteForSiteAnnee != null)
            {
                if (LastDialogueSecuriteForSiteAnnee.Date.Year == dialogueSecurite.Date.Year)
                {
                    dialogueSecurite.CompteurAnnuelSite = LastDialogueSecuriteForSiteAnnee.CompteurAnnuelSite + 1;
                }
            }

            Site site = db.Sites.First(s => s.SiteID == dialogueSecurite.SiteId);
            dialogueSecurite.Code += site.Trigramme + "-" + dialogueSecurite.Date.Year + "-" + dialogueSecurite.CompteurAnnuelSite;

            db.DialogueSecurites.Add(dialogueSecurite);

            try
            {
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, dialogueSecurite);
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        public HttpResponseMessage Delete(int id)
        {
            DialogueSecurite dialogueSecurite = db.DialogueSecurites.Find(id);
            if (dialogueSecurite == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.DialogueSecurites.Remove(dialogueSecurite);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DialogueSecuriteExists(int id)
        {
            return db.DialogueSecurites.Count(e => e.Id == id) > 0;
        }

    }
}
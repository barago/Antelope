using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Services.Socle;
using Antelope.Services.HSE;


namespace Antelope.Controllers.API.QSE
{
    public class ActionQSEController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();

        private PersonneAnnuaireService _personneAnnuaireService { get; set; }
        private FicheSecuriteServices _ficheSecuriteServices { get; set; }

        public ActionQSEController()
        {
            _personneAnnuaireService = new PersonneAnnuaireService(db);
        }

        // GET api/ActionQSE
        public IQueryable<ActionQSE> GetActions()
        {
            return db.ActionQSEs;
        }

        // GET api/ActionQSE/5
        [ResponseType(typeof(ActionQSE))]
        public IHttpActionResult GetActionQSE(int id)
        {
            ActionQSE actionqse = db.ActionQSEs.Find(id);
            if (actionqse == null)
            {
                return NotFound();
            }

            return Ok(actionqse);
        }

        // PUT api/ActionQSE/5
        public IHttpActionResult PutActionQSE(int id, ActionQSE actionqse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actionqse.ActionQSEId)
            {
                return BadRequest();
            }

            db.Entry(actionqse).State = EntityState.Modified;

            try
            {
                if (actionqse.ResponsableId == 0)
                {
                    actionqse.Responsable = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                        actionqse.Responsable.Nom, actionqse.Responsable.Prenom, actionqse.ResponsableId, db
                    );
                }

                if (actionqse.VerificateurId == 0)
                {
                    actionqse.Responsable = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                        actionqse.Responsable.Nom, actionqse.Responsable.Prenom, actionqse.ResponsableId, db
                    );
                }

                    db.SaveChanges();

                    _ficheSecuriteServices = new FicheSecuriteServices();
                    _ficheSecuriteServices.FicheSecuriteOpenOrClose(actionqse);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionQSEExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ActionQSE
        //[ResponseType(typeof(ActionQSE))]
        public HttpResponseMessage PostActionQSE(ActionQSE actionQSE)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            actionQSE.Responsable = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                actionQSE.Responsable.Nom, actionQSE.Responsable.Prenom, actionQSE.ResponsableId, db
            );
            if (actionQSE.VerificateurId != 0 && actionQSE.VerificateurId != null)
            {
            actionQSE.Verificateur = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                actionQSE.Verificateur.Nom, actionQSE.Verificateur.Prenom, actionQSE.VerificateurId, db
            );

            }
            db.ActionQSEs.Add(actionQSE);
            db.SaveChanges();

            return Request.CreateResponse<ActionQSE>(HttpStatusCode.OK, actionQSE, Configuration.Formatters.JsonFormatter);
        }

        // DELETE api/ActionQSE/5
        [ResponseType(typeof(ActionQSE))]
        public IHttpActionResult DeleteActionQSE(int id)
        {
            ActionQSE actionqse = db.ActionQSEs.Find(id);
            if (actionqse == null)
            {
                return NotFound();
            }

            db.ActionQSEs.Remove(actionqse);
            db.SaveChanges();

            return Ok(actionqse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActionQSEExists(int id)
        {
            return db.ActionQSEs.Count(e => e.ActionQSEId == id) > 0;
        }
    }
}
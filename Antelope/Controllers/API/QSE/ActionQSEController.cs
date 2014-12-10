﻿using System;
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
        public HttpResponseMessage PutActionQSE(int id, ActionQSE actionqse)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Configuration.Formatters.JsonFormatter);
            }

            if (id != actionqse.ActionQSEId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Configuration.Formatters.JsonFormatter);
            }


            var currentAction = db.ActionQSEs.Find(actionqse.ActionQSEId);
            db.Entry(currentAction).CurrentValues.SetValues(actionqse);

            db.Entry(currentAction).State = EntityState.Modified;

            try
            {
                if (currentAction.ResponsableId == 0)
                {
                    currentAction.Responsable = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                        currentAction.Responsable.Nom, currentAction.Responsable.Prenom, currentAction.ResponsableId, db
                    );
                }

                if (currentAction.VerificateurId == 0)
                {
                    currentAction.Responsable = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                        currentAction.Responsable.Nom, currentAction.Responsable.Prenom, currentAction.ResponsableId, db
                    );
                }

                    db.SaveChanges();

                    if (currentAction.NonConformiteId == 0 && currentAction.NonConformiteId == null)
                    {
                        _ficheSecuriteServices = new FicheSecuriteServices();
                        _ficheSecuriteServices.FicheSecuriteOpenOrClose(currentAction);
                    }

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionQSEExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, currentAction, Configuration.Formatters.JsonFormatter);
                //StatusCode(HttpStatusCode.NoContent, currentAction, Configuration.Formatters.JsonFormatter);
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
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


namespace Antelope.Controllers.API.QSE
{
    public class ActionQSEController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();

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
                    Personne responsable = new Personne() { 
                        Nom = actionqse.Responsable.Nom,
                        Prenom = actionqse.Responsable.Prenom,
                        Guid = actionqse.Responsable.Guid
                    };
                    actionqse.Responsable = responsable;
                }
                
                db.SaveChanges();
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
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
using Antelope.Models;
using Antelope.Models.QSE;

namespace Antelope.Controllers.API.QSE
{
    public class CauseQSEController : ApiController
    {
        private AntelopeContext db = new AntelopeContext();

        // GET: api/CauseQSE
        public IQueryable<CauseQSE> GetCauses()
        {
            return db.Causes;
        }

        // GET: api/CauseQSE/5
        [ResponseType(typeof(CauseQSE))]
        public IHttpActionResult GetCauseQSE(int id)
        {
            CauseQSE causeQSE = db.Causes.Find(id);
            if (causeQSE == null)
            {
                return NotFound();
            }

            return Ok(causeQSE);
        }

        // PUT: api/CauseQSE/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutCauseQSE(int id, CauseQSE causeQSE)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Configuration.Formatters.JsonFormatter); // param : ModelState à voir
            }

            if (id != causeQSE.CauseQSEId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Configuration.Formatters.JsonFormatter);
            }

            db.Entry(causeQSE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CauseQSEExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, Configuration.Formatters.JsonFormatter);
        }


        public HttpResponseMessage Post(CauseQSE causeQSE/* [FromBody]string value */)
        {
            db.Causes.Add(causeQSE);
            db.SaveChanges();

            return Request.CreateResponse<CauseQSE>(HttpStatusCode.OK, causeQSE, Configuration.Formatters.JsonFormatter);
        }


        // DELETE: api/CauseQSE/5
        [ResponseType(typeof(CauseQSE))]
        public IHttpActionResult DeleteCauseQSE(int id)
        {
            CauseQSE causeQSE = db.Causes.Find(id);
            if (causeQSE == null)
            {
                return NotFound();
            }

            db.Causes.Remove(causeQSE);
            db.SaveChanges();

            return Ok(causeQSE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CauseQSEExists(int id)
        {
            return db.Causes.Count(e => e.CauseQSEId == id) > 0;
        }



        // POST: api/CauseQSE
        //[ResponseType(typeof(CauseQSE))]
        //public IHttpActionResult PostCauseQSE(CauseQSE causeQSE)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Causes.Add(causeQSE);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = causeQSE.CauseQSEId }, causeQSE);
        //}
    }
}
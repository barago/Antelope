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
using Antelope.Repositories.Socle;
using Antelope.ViewModels.QSE.NonConformiteViewModels;

namespace Antelope.Controllers.API.QSE
{
    public class NonConformiteController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }


        // GET: api/NonConformite
        public IQueryable<NonConformite> GetNonConformites()
        {
            return db.NonConformites;
        }

        // GET: api/NonConformite/5
        [ResponseType(typeof(NonConformite))]
        public HttpResponseMessage Get(int id)
        {
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
            
            NonConformite nonConformite;

            //if (id == -1)
            //{
                Site SiteUser = _activeDirectoryUtilisateurRepository.GetCurrentUserSite();

                nonConformite = new NonConformite()
                {
                   SiteId = SiteUser.SiteID
                };


            //}
            //else
            //{


            //}

            var nonConformiteViewModel = new NonConformiteViewModel(nonConformite);
            return Request.CreateResponse(HttpStatusCode.OK, nonConformiteViewModel);
        }

        // PUT: api/NonConformite/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNonConformite(int id, NonConformite nonConformite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nonConformite.Id)
            {
                return BadRequest();
            }

            db.Entry(nonConformite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NonConformiteExists(id))
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

        // POST: api/NonConformite
        [ResponseType(typeof(NonConformite))]
        public IHttpActionResult PostNonConformite(NonConformite nonConformite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NonConformites.Add(nonConformite);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nonConformite.Id }, nonConformite);
        }

        // DELETE: api/NonConformite/5
        [ResponseType(typeof(NonConformite))]
        public IHttpActionResult DeleteNonConformite(int id)
        {
            NonConformite nonConformite = db.NonConformites.Find(id);
            if (nonConformite == null)
            {
                return NotFound();
            }

            db.NonConformites.Remove(nonConformite);
            db.SaveChanges();

            return Ok(nonConformite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NonConformiteExists(int id)
        {
            return db.NonConformites.Count(e => e.Id == id) > 0;
        }
    }
}
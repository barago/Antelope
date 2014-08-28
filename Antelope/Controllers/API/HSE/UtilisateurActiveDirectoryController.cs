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
using Antelope.Models.Socle;
using Antelope.ViewModels.Socle.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace Antelope.Controllers.API.HSE
{
    public class UtilisateurActiveDirectoryController : ApiController
    {
        private AntelopeContext db = new AntelopeContext();

        // GET: api/UtilisateurActiveDirectory
        public IQueryable<Lieu> GetLieux()
        {
            return db.Lieux;
        }

        public HttpResponseMessage GetUtilisateurActiveDirectoryByNomPrenom(int id, string param1, string param2)  // [FromUri] ActiveDirectoryUtilisateurViewModel activeDirectoryUtilisateurViewModel
        {

            var a = 0;

            using (var context = new PrincipalContext(ContextType.Domain, "refresco.local"))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        System.Diagnostics.Debug.WriteLine("First Name: " + de.Properties["givenName"].Value);
                        Console.WriteLine("Last Name : " + de.Properties["sn"].Value);
                        Console.WriteLine("SAM account name   : " + de.Properties["samAccountName"].Value);
                        Console.WriteLine("User principal name: " + de.Properties["userPrincipalName"].Value);
                        Console.WriteLine();
                    }
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, a);
        }

        // GET: api/UtilisateurActiveDirectory/5
        [ResponseType(typeof(Lieu))]
        public IHttpActionResult GetLieu(int id)
        {
            Lieu lieu = db.Lieux.Find(id);
            if (lieu == null)
            {
                return NotFound();
            }

            return Ok(lieu);
        }

        // PUT: api/UtilisateurActiveDirectory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLieu(int id, Lieu lieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lieu.LieuID)
            {
                return BadRequest();
            }

            db.Entry(lieu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LieuExists(id))
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

        // POST: api/UtilisateurActiveDirectory
        [ResponseType(typeof(Lieu))]
        public IHttpActionResult PostLieu(Lieu lieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lieux.Add(lieu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lieu.LieuID }, lieu);
        }

        // DELETE: api/UtilisateurActiveDirectory/5
        [ResponseType(typeof(Lieu))]
        public IHttpActionResult DeleteLieu(int id)
        {
            Lieu lieu = db.Lieux.Find(id);
            if (lieu == null)
            {
                return NotFound();
            }

            db.Lieux.Remove(lieu);
            db.SaveChanges();

            return Ok(lieu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LieuExists(int id)
        {
            return db.Lieux.Count(e => e.LieuID == id) > 0;
        }
    }
}
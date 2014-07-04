using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antelope.Models.HSE;
using Antelope.Services.HSE;
using Antelope.Services.Commons;
using System.Diagnostics;
using PagedList;
using Antelope.Models;
using Antelope.Models.Socle;
using System.Web.Security;
using System.Collections;


namespace Antelope.Controllers.HSE
{
    public class FicheSecuriteController : Controller
    {
        private AntelopeContext db = new AntelopeContext();


        //[Authorize(Roles = "RFC-U-Informatique_ResponsableApplications")]
        //[Authorize]
        // GET: /FicheSecurite/
        public ActionResult Index(string sortOrder, string searchString, int page = 1)
        {

            var ficheSecurites = from s in db.FicheSecurites.Include(f => f.Site)   //Include > JOINTURE EAGER
                                 select s;



            FicheSecuriteServices.AddTriParamsToViewBag(ViewBag, sortOrder);
            ViewBag.CurrentSort = sortOrder;

            ViewBag.SearchString = searchString != null ? searchString : "";

            if (!String.IsNullOrEmpty(searchString))
            {
                ficheSecurites = ficheSecurites.Where(f => f.Code.ToUpper().Contains(searchString.ToUpper()));
            }


            ficheSecurites = FicheSecuriteServices.TriFicheSecurites(ficheSecurites, sortOrder);

            int pageSize = 8;

            return View("~/Views/HSE/FicheSecurite/Index.cshtml", ficheSecurites.ToPagedList(page, pageSize));
        }



        // GET: /FicheSecurite/Create
        public ActionResult Create()
        {
            List<Zone> Zones = new List<Zone>();
            List<Lieu> Lieux = new List<Lieu>();
            ViewBag.SiteId = new SelectList(db.Sites, "SiteID", "Trigramme");
            ViewBag.ZoneId = new SelectList(Zones, "ZoneId", "Nom");
            ViewBag.LieuId = new SelectList(Lieux, "LieuId", "Nom");
            ViewBag.FicheSecuriteTypeId = new SelectList(db.FicheSecuriteTypes, "FicheSecuriteTypeId", "Nom");
            ViewBag.DangerId = new SelectList(db.Dangers, "DangerId", "Nom");
            ViewBag.PlageHoraireId = new SelectList(db.PlageHoraires, "PlageHoraireId", "Nom");


            return View("~/Views/HSE/FicheSecurite/Create.cshtml");
        }

        // POST: /FicheSecurite/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DateTime DateEvenement, Boolean HeureEvenementValide, [Bind(Include = "FicheSecuriteID,Code,Type,Nom,Prenom,PosteDeTravail,DateCreation,Service,Responsable,ZoneId,LieuId,PersonnesConcernees,Description,CotationFrequence,CotationGravite,CotationVolume,SiteId,FicheSecuriteTypeId,Risque,Age,PlageHoraireId,Temoins,ActionImmediate1,ActionImmediate2,CorpsHumainZone")] FicheSecurite ficheSecurite)
        {
            
            TimeSpan ts = new TimeSpan(10, 30, 0);
            //ficheSecurite.DateEvenement = HeureEvenementValide ? ficheSecurite.DateEvenement : 
            var errors = ViewData.ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
            if (ModelState.IsValid)
            {
                db.FicheSecurites.Add(ficheSecurite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Zone> Zones = new List<Zone>();
            List<Lieu> Lieux = new List<Lieu>();

            String[] roles = Roles.GetRolesForUser();
            //foreach (String NomRole in roles){
            //    Console.WriteLine("Role : " + NomRole);

            //}


            //Site site = db.Sites.Find;

            ViewBag.SiteId = new SelectList(db.Sites, "SiteID", "Trigramme", ficheSecurite.SiteId);
            ViewBag.ZoneId = new SelectList(Zones, "ZoneId", "Nom");
            ViewBag.LieuId = new SelectList(Lieux, "LieuId", "Nom");
            ViewBag.FicheSecuriteTypeId = new SelectList(db.FicheSecuriteTypes, "FicheSecuriteTypeId", "Nom");
            ViewBag.DangerId = new SelectList(db.Dangers, "DangerId", "Nom");
            ViewBag.PlageHoraireId = new SelectList(db.PlageHoraires, "PlageHoraireId", "Nom");

            ViewBag.DateEvenement = ficheSecurite.DateEvenement.Date.ToString("dd/MM/yyyy");
            ViewBag.HeureEvenement = ficheSecurite.DateEvenement.Date.ToString("HH:mm");

            return View("~/Views/HSE/FicheSecurite/Create.cshtml", ficheSecurite);
        }

        // GET: /FicheSecurite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FicheSecurite ficheSecurite = db.FicheSecurites.Find(id);
            if (ficheSecurite == null)
            {
                return HttpNotFound();
            }

            //User.IsInRole("xxx");

            ArrayList groups = GroupService.GetAllGroupForUser();
            String[] roles = Roles.GetRolesForUser();

            ViewBag.SiteId = new SelectList(db.Sites, "SiteID", "Nom", ficheSecurite.SiteId);
            var queryZone = from a in db.Zones
                            where a.SiteId == ficheSecurite.SiteId
                            select a;

            ViewBag.ZoneId = new SelectList(queryZone, "ZoneId", "Nom", ficheSecurite.ZoneId);

            var queryLieu = from a in db.Lieux
                            where a.ZoneId == ficheSecurite.LieuId
                            select a;

            ViewBag.LieuId = new SelectList(queryLieu, "LieuId", "Nom", ficheSecurite.LieuId);
            ViewBag.FicheSecuriteTypeId = new SelectList(db.FicheSecuriteTypes, "FicheSecuriteTypeId", "Nom");
            ViewBag.DangerId = new SelectList(db.Dangers, "DangerId", "Nom");
            ViewBag.PlageHoraireId = new SelectList(db.PlageHoraires, "PlageHoraireId", "Nom");

            ViewBag.DateEvenement = ficheSecurite.DateEvenement.Date.ToString("dd/MM/yyyy");
            ViewBag.HeureEvenement = ficheSecurite.DateEvenement.Date.ToString("HH:mm");

            ViewBag.CriticiteBrute = ficheSecurite.CotationFrequence * ficheSecurite.CotationGravite;

            return View("~/Views/HSE/FicheSecurite/Create.cshtml", ficheSecurite);
        }

        // POST: /FicheSecurite/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Boolean HeureEvenementValide, [Bind(Include = "FicheSecuriteID,Code,Type,Nom,Prenom,PosteDeTravail,Service,Responsable,DateCreation,Zone,Lieu,PersonnesConcernees,Description,CotationFrequence,CotationGravite,CotationVolume,SiteId,FicheSecuriteTypeId,Risque,Age,PlageHoraireId,Temoins, ActionImmediate1, ActionImmediate2,CorpsHumainZone")] FicheSecurite ficheSecurite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ficheSecurite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SiteId = new SelectList(db.Sites, "SiteID", "Nom", ficheSecurite.SiteId);
            ViewBag.FicheSecuriteTypeId = new SelectList(db.FicheSecuriteTypes, "FicheSecuriteTypeId", "Nom");
            ViewBag.DangerId = new SelectList(db.Dangers, "DangerId", "Nom");
            ViewBag.PlageHoraireId = new SelectList(db.PlageHoraires, "PlageHoraireId", "Nom");

            //int CotationFrequence = ficheSecurite.CotationFrequence != null ? ficheSecurite.CotationFrequence : 0;
            //int CotationGravite = ficheSecurite.CotationGravite != null ? ficheSecurite.CotationGravite : 0;

            ViewBag.CriticiteBrute = ficheSecurite.CotationFrequence * ficheSecurite.CotationGravite;

            return View("~/Views/HSE/FicheSecurite/Edit.cshtml", ficheSecurite);
        }

        // GET: /FicheSecurite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FicheSecurite ficheSecurite = db.FicheSecurites.Find(id);
            if (ficheSecurite == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/HSE/FicheSecurite/Delete.cshtml", ficheSecurite);
        }

        public ActionResult TestMap()
        {


            return View("~/Views/HSE/FicheSecurite/TestMap.cshtml");
        }

        // POST: /FicheSecurite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FicheSecurite ficheSecurite = db.FicheSecurites.Find(id);
            db.FicheSecurites.Remove(ficheSecurite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Zones(string SiteId)
        {

            if (SiteId == "" || SiteId == "undefined")
            {
                return Json(new SelectList(new List<Zone>(), "ZoneId", "Nom"));
            }

            int id = Convert.ToInt32(SiteId);


            var query = from a in db.Zones
                        where a.SiteId == id
                        select a;

            return Json(new SelectList(query, "ZoneId", "Nom"));

        }

        [HttpPost]
        public ActionResult Lieux(string ZoneId)
        {

            if (ZoneId == "" || ZoneId == "undefined")
            {
                return Json(new SelectList(new List<Lieu>(), "LieuId", "Nom"));
            }

            int id = Convert.ToInt32(ZoneId);


            var query = from a in db.Lieux
                        where a.ZoneId == id
                        select a;

            return Json(new SelectList(query, "LieuId", "Nom"));

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: /FicheSecurite/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FicheSecurite ficheSecurite = db.FicheSecurites.Find(id);
        //    if (ficheSecurite == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View("~/Views/HSE/FicheSecurite/Details.cshtml", ficheSecurite);
        //}

    }
}

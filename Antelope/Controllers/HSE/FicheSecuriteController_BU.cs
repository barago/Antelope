using Antelope.Models;
using Antelope.Models.HSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.HSE
{
    public class FicheSecuriteController_BU : Controller
    {

        private AntelopeContext context = new AntelopeContext();
        
        //
        // GET: /FicheSecurite/
        public ActionResult Index()
        {
            List<FicheSecurite> FicheSecurites = context.FicheSecurites.ToList();
            return View("~/Views/HSE/FicheSecurite/Index.cshtml", FicheSecurites);
        }

        //
        // GET: /FicheSecurite/Details/5
        public ActionResult Details(int id = 0)
        {

            FicheSecurite FicheSecurite = context.FicheSecurites.Find(id);

            if(FicheSecurite == null){
                return HttpNotFound();
            }

            return View("~/Views/HSE/FicheSecurite/Details.cshtml");
        }

        // Exemple de filtre : [Authorize (Roles = "Administrator"); ]
        // 
        // GET: /FicheSecurite/Create
        public ActionResult Create()
        {
            return View("~/Views/HSE/FicheSecurite/Create.cshtml");
        }

        //
        // POST: /FicheSecurite/Create
        [HttpPost]
        public ActionResult Create(FicheSecurite ficheSecurite)
        {

            if(!ModelState.IsValid){
                return View("~/Views/HSE/FicheSecurite/Create.cshtml", ficheSecurite);
            }

            try
            {
                context.FicheSecurites.Add(ficheSecurite);
                context.SaveChanges();
                TempData["Message"] = ficheSecurite.Code + "à été créé avec succès";

                return RedirectToAction("Index");
            }
            catch(Exception Ex)
            {
                ModelState.AddModelError("Erreur", Ex.Message);
                return View("~/Views/HSE/FicheSecurite/Create.cshtml", ficheSecurite);
            }
        }

        //
        // GET: /FicheSecurite/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /FicheSecurite/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FicheSecurite/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /FicheSecurite/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

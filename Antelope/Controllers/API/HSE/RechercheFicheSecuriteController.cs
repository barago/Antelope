using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Antelope.Models.HSE;
using Antelope.Models.Socle;
using Antelope.Models;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using Antelope.Repositories.HSE;



namespace Antelope.Controllers.API.HSE
{
    public class RechercheFicheSecuriteController : ApiController
    {

        private AntelopeContext db = new AntelopeContext();
        public FicheSecuriteRepository _ficheSecuriteRepository { get; set; }



        // GET: api/RechercheFicheSecurite
        public HttpResponseMessage Get()
        {

            _ficheSecuriteRepository = new FicheSecuriteRepository();

            var AllFicheSecurite = _ficheSecuriteRepository.GetAll();

            //List<Site> AllSite = db.Sites.ToList();
            List<Zone> AllZone = new List<Zone>();  // db.Zones.ToList();
            List<Lieu> AllLieu = db.Lieux.ToList();
            List<PosteDeTravail> AllPosteDeTravail = db.PosteDeTravails.ToList();

            var RechercheFicheSecuriteViewModel = new RechercheFicheSecuriteViewModel(AllFicheSecurite, AllZone, AllLieu, AllPosteDeTravail);
            return Request.CreateResponse(HttpStatusCode.OK, RechercheFicheSecuriteViewModel);
        }

        // GET: api/RechercheFicheSecurite/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RechercheFicheSecurite
        public HttpResponseMessage Post([FromBody]string value)
        {

            //List<Site> AllSite = db.Sites.ToList();
            //List<Zone> AllZone = db.Zones.ToList();
            //List<Lieu> AllLieu = db.Lieux.ToList();
            //List<PosteDeTravail> AllPosteDeTravail = db.PosteDeTravails.ToList();

            //var RechercheFicheSecuriteViewModel = new RechercheFicheSecuriteViewModel(AllZone, AllLieu, AllPosteDeTravail);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        // PUT: api/RechercheFicheSecurite/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RechercheFicheSecurite/5
        public void Delete(int id)
        {
        }
    }
}

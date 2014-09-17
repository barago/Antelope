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
            List<Service> AllService = db.Services.ToList();

            var RechercheFicheSecuriteViewModel = new RechercheFicheSecuriteViewModel(AllFicheSecurite,AllService, AllZone, AllLieu, AllPosteDeTravail);
            return Request.CreateResponse(HttpStatusCode.OK, RechercheFicheSecuriteViewModel);
        }

        // GET: api/RechercheFicheSecurite/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RechercheFicheSecurite
        public HttpResponseMessage Post(RechercheFicheSecuriteParamModel RechercheFicheSecuriteParamModel)
        {

            _ficheSecuriteRepository = new FicheSecuriteRepository();

            //----------------------------
            var queryFicheSecurite = from a in db.FicheSecurites select a;

            if(RechercheFicheSecuriteParamModel.SiteId != null && RechercheFicheSecuriteParamModel.SiteId != 0){                         
                queryFicheSecurite = queryFicheSecurite.Where(q => q.SiteId == RechercheFicheSecuriteParamModel.SiteId);
            }
            if (RechercheFicheSecuriteParamModel.ZoneId != null && RechercheFicheSecuriteParamModel.ZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.ZoneId == RechercheFicheSecuriteParamModel.ZoneId);
            }
            if (RechercheFicheSecuriteParamModel.LieuId != null && RechercheFicheSecuriteParamModel.LieuId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.LieuId == RechercheFicheSecuriteParamModel.LieuId);
            }    
 



            List<FicheSecurite> AllFicheSecurite = queryFicheSecurite.ToList();


            //-----------------------------

            //List<FicheSecurite> AllFicheSecurite = _ficheSecuriteRepository.GetAll();
            //List<FicheSecurite> AllFicheSecurite2 = new List<FicheSecurite>();
            //AllFicheSecurite2.Add(AllFicheSecurite[1]);

            return Request.CreateResponse(HttpStatusCode.OK, AllFicheSecurite);

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

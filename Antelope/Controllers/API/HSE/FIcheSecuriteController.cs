using Antelope.Models;
using Antelope.Models.Socle;
using Antelope.Repositories.HSE;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.HSE
{
    public class FIcheSecuriteController : ApiController
    {
        
        public FicheSecuriteRepository _ficheSecuriteRepository {get; set;}
        private AntelopeContext db = new AntelopeContext();

        public FIcheSecuriteController() {

            _ficheSecuriteRepository = new FicheSecuriteRepository();
        }
        
        // GET api/fichesecuriteapi
        //public IEnumerable<string> Get()
        //{
        //    var ficheSecurites = _ficheSecuriteRepository.GetAll();
        //    return ficheSecurites;
        //}

        // GET api/fichesecuriteapi/5
        public HttpResponseMessage Get(int id)
        {

            var ficheSecurite = _ficheSecuriteRepository.Get(id);
            if (ficheSecurite == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var queryZone = from a in db.Zones
                            where a.SiteId == ficheSecurite.SiteId
                            select a;
            List<Zone> AllZone = queryZone.ToList();

            var queryLieu = from a in db.Lieux
                            where a.ZoneId == ficheSecurite.LieuId
                            select a;
            List<Lieu> AllLieu = queryLieu.ToList();

            var ficheSecuriteViewModel = new FicheSecuriteViewModel(ficheSecurite, AllZone, AllLieu);
            return Request.CreateResponse(HttpStatusCode.OK, ficheSecuriteViewModel);
        }


        // POST api/fichesecuriteapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/fichesecuriteapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/fichesecuriteapi/5
        public void Delete(int id)
        {
        }
    }
}

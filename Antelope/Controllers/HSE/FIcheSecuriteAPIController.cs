using Antelope.Repositories.HSE;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.HSE
{
    public class FIcheSecuriteAPIController : ApiController
    {
        
        public FicheSecuriteRepository _ficheSecuriteRepository {get; set;}

        public FIcheSecuriteAPIController() {

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

            var ficheSecuriteViewModel = new FicheSecuriteViewModel(ficheSecurite);
            return Request.CreateResponse(HttpStatusCode.OK, ficheSecurite);
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

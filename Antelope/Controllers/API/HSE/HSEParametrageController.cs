using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Services.Socle.DataBaseHydratation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.HSE
{
    public class HSEParametrageController : ApiController
    {

        private AntelopeEntities context = new AntelopeEntities();
        private DataBaseTestHydratationService _dataBaseTestHydratationService = new DataBaseTestHydratationService();
        private DataBaseAcceptanceHydratationService _dataBaseAcceptanceHydratationService = new DataBaseAcceptanceHydratationService();

        [AcceptVerbs("GET")]       
        public HttpResponseMessage GetHSEParametrage()
        {
            ParametrageHSE ParametrageHSE = context.ParametrageHSEs.FirstOrDefault();

            if (ParametrageHSE == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK , ParametrageHSE);
        }

        public HttpResponseMessage saveParametrageHSEEmail(ParametrageHSE parametrageHSE)
        {
           //ParametrageHSE ParametrageHSE = context.ParametrageHSEs.FirstOrDefault(p => p.Id == parametrageHSE.Id);
           //ParametrageHSE.EmailDiffusionFS = parametrageHSE.EmailDiffusionFS;
           context.Entry(parametrageHSE).State = EntityState.Modified;
           context.SaveChanges();


            return Request.CreateResponse(HttpStatusCode.OK, parametrageHSE);
        }


        [AcceptVerbs("POST")]
        public HttpResponseMessage AlimenteBaseTest()
        {
            _dataBaseTestHydratationService.FullDataBaseTestHydrate();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage AlimenteBaseAcceptance()
        {
            _dataBaseAcceptanceHydratationService.FullDataBaseAcceptanceHydrate();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage AlimenteListeNSG()
        {
            _dataBaseTestHydratationService.FullDataBaseTestHydrate();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}

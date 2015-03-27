using Antelope.Domain.Models;
using Antelope.DTOs.HSE;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.HSE
{
    public class HSEStatistiqueController : ApiController
    {

        private AntelopeEntities db = new AntelopeEntities();

        public HttpResponseMessage GetHSEStatistique()
        {

            DateTime DateDebut = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime DateFin = DateTime.Now.Date;

            var queryFicheSecurite = from f in db.FicheSecurites
                                     where f.DateEvenement >= DateDebut
                                     && f.DateEvenement <= DateFin
                                     select new FicheSecuriteStatistique { Id = f.FicheSecuriteID, DateEvnmt = f.DateEvenement, SiteId = f.SiteId, Site = f.Site.Trigramme, ZoneId = f.ZoneId, CauseQSEs = f.CauseQSEs, FicheSecuriteType = f.FicheSecuriteType.Nom};

            var AllFicheSecurite = queryFicheSecurite.ToList();

            foreach (var FS in AllFicheSecurite)
            {
                FS.TimeStamp = (Int32)(FS.DateEvnmt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            List<Site> AllSite = db.Sites.ToList();
            List<Zone> AllZone = db.Zones.ToList();

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Dictionary<string, Object> ParamModel = new Dictionary<string, Object>();
            Response.Add("AllFicheSecurite", AllFicheSecurite);
            Response.Add("AllSite", AllSite);
            Response.Add("AllZone", AllZone);
            ParamModel.Add("DateDebut", DateDebut);
            ParamModel.Add("DateFin", DateFin);
            Response.Add("ParamModel", ParamModel);


            return Request.CreateResponse(HttpStatusCode.OK, Response);
        }

        public HttpResponseMessage StatistiqueFiltered(StatistiquePyramideParamModel statistiquePyramideParamModel)
        {

            //Dictionary<string, string> DataTableParameters = new Dictionary<string, string>();
            //DataTableParameters = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            DateTime ParameterDateDebut = statistiquePyramideParamModel.DateDebut;
            DateTime ParameterDateFin = statistiquePyramideParamModel.DateFin;

            DateTime DateDebut = ParameterDateDebut;
            DateTime DateFin = ParameterDateFin;

            var queryFicheSecurite = from f in db.FicheSecurites
                                     where f.DateEvenement >= DateDebut
                                     && f.DateEvenement <= DateFin
                                     select new FicheSecuriteStatistique { Id = f.FicheSecuriteID, DateEvnmt = f.DateEvenement, SiteId = f.SiteId, Site = f.Site.Trigramme, ZoneId = f.ZoneId, CauseQSEs = f.CauseQSEs, FicheSecuriteType = f.FicheSecuriteType.Nom };

            var AllFicheSecurite = queryFicheSecurite.ToList();

            foreach (var FS in AllFicheSecurite)
            {
                FS.TimeStamp = (Int32)(FS.DateEvnmt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Response.Add("AllFicheSecurite", AllFicheSecurite);


            return Request.CreateResponse(HttpStatusCode.OK, AllFicheSecurite);
        }


    }
}

using Antelope.Domain.Models;
using Antelope.DTOs.HSE;
using Antelope.Infrastructure.EntityFramework;
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

            var queryFicheSecurite = from f in db.FicheSecurites
                                //where f.Trigramme == SiteTrigramme
                                     select new FicheSecuriteStatistique { Id = f.FicheSecuriteID, DateEvnmt = f.DateEvenement, Site = f.Site.Trigramme, CauseQSEs = f.CauseQSEs};

            var AllFicheSecurite = queryFicheSecurite.ToList();

     
             //List<FicheSecuriteStatistique> AllFicheSecuriteStatistique = new List<FicheSecuriteStatistique>();


            
            foreach (var FS in AllFicheSecurite)
            {
                FS.TimeStamp = (Int32)(FS.DateEvnmt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                //    AllFicheSecuriteStatistique.Add(; //ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);  //(Int32)(FS.DateEvnmt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds ;
                //    AllFicheSecuriteStatistique.Add(
            //        new FicheSecuriteStatistique(){

            //        }
            //        );    
            //    //FS["TimeStamp"] = (dt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
            }

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Response.Add("AllFicheSecurite", AllFicheSecurite);

            return Request.CreateResponse(HttpStatusCode.OK, Response);
        }


    }
}

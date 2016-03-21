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
            DateTime DateFin = DateTime.Now.AddDays(+1);

            var queryFicheSecurite = from f in db.FicheSecurites
                                     where f.DateEvenement >= DateDebut
                                     && f.DateEvenement <= DateFin
                                     select new FicheSecuriteStatistique { Id = f.FicheSecuriteID, DateEvnmt = f.DateEvenement, SiteId = f.SiteId, Site = f.Site.Trigramme, ZoneId = f.ZoneId, ServiceId = f.ServiceId, CauseQSEs = f.CauseQSEs, FicheSecuriteType = f.FicheSecuriteType.Nom, Responsable = f.Responsable, FicheSecurtiteTypeID = f.FicheSecuriteTypeId, WorkFlowASEValidee = f.WorkFlowASEValidee, WorkFlowFicheSecuriteCloturee = f.WorkFlowFicheSecuriteCloturee, WorkFlowCloturee = f.WorkFlowCloturee };

            var AllFicheSecurite = queryFicheSecurite.ToList();

            foreach (var FS in AllFicheSecurite)
            {
                FS.TimeStamp = (Int32)(FS.DateEvnmt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            List<Site> AllSite = db.Sites.ToList();
            List<Zone> AllZone = db.Zones.ToList();
            List<Service> AllService = db.Services.ToList();
            List<FicheSecuriteType> AllFicheSecuriteType = db.FicheSecuriteTypes.ToList();

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Dictionary<string, Object> ParamModel = new Dictionary<string, Object>();
            Response.Add("AllFicheSecurite", AllFicheSecurite);
            Response.Add("AllSite", AllSite);
            Response.Add("AllZone", AllZone);
            Response.Add("AllService", AllService);
            Response.Add("AllFicheSecuriteType", AllFicheSecuriteType);
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
            DateTime DateFin = ParameterDateFin.AddDays(+1);

            var queryFicheSecurite = from f in db.FicheSecurites
                                     where f.DateEvenement >= DateDebut
                                     && f.DateEvenement <= DateFin
                                     select new FicheSecuriteStatistique { Id = f.FicheSecuriteID, DateEvnmt = f.DateEvenement, SiteId = f.SiteId, Site = f.Site.Trigramme, ZoneId = f.ZoneId, ServiceId = f.ServiceId, CauseQSEs = f.CauseQSEs, FicheSecuriteType = f.FicheSecuriteType.Nom, Responsable = f.Responsable, FicheSecurtiteTypeID = f.FicheSecuriteTypeId, WorkFlowASEValidee = f.WorkFlowASEValidee, WorkFlowFicheSecuriteCloturee = f.WorkFlowFicheSecuriteCloturee, WorkFlowCloturee = f.WorkFlowCloturee };

            var AllFicheSecurite = queryFicheSecurite.ToList();

            foreach (var FS in AllFicheSecurite)
            {
                FS.TimeStamp = (Int32)(FS.DateEvnmt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Response.Add("AllFicheSecurite", AllFicheSecurite);


            return Request.CreateResponse(HttpStatusCode.OK, AllFicheSecurite);
        }

        public HttpResponseMessage GetDialogueSecuriteStatistique()
        {

            DateTime DateDebut = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime DateFin = DateTime.Now.AddDays(+1);

            var queryDialogueSecurite = from d in db.DialogueSecurites
                                     where d.Date >= DateDebut
                                     && d.Date <= DateFin
                                        select new DialogueSecuriteStatistique { 
                                            Id = d.Id, Date = d.Date, SiteId = d.SiteId, Site = d.Site.Trigramme, 
                                            ZoneId = d.ZoneId, Dialogueur1Id = d.Dialogueur1Id, Dialogueur2Id = d.Dialogueur2Id, 
                                            Dialogueur3Id = d.Dialogueur3Id, Entretenu1Id = d.Entretenu1Id, 
                                            Entretenu2Id = d.Entretenu2Id, Entretenu3Id = d.Entretenu3Id, 
                                            Dialogueur1 = d.Dialogueur1, Dialogueur2 = d.Dialogueur2, Dialogueur3 = d.Dialogueur3,
                                            Entretenu1 = d.Entretenu1, Entretenu2 = d.Entretenu2, Entretenu3 = d.Entretenu3
                                        };

            var AllDialogueSecurite = queryDialogueSecurite.ToList();

            foreach (var DS in AllDialogueSecurite)
            {
                DS.TimeStamp = (Int32)(DS.Date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            List<Site> AllSite = db.Sites.ToList();
            List<Zone> AllZone = db.Zones.ToList();
            List<Service> AllService = db.Services.ToList();
            List<Thematique> AllThematique = db.Thematiques.ToList();

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Dictionary<string, Object> ParamModel = new Dictionary<string, Object>();
            Response.Add("AllDialogueSecurite", AllDialogueSecurite);
            Response.Add("AllSite", AllSite);
            Response.Add("AllZone", AllZone);
            Response.Add("AllService", AllService);
            Response.Add("AllThematique", AllThematique);
            ParamModel.Add("DateDebut", DateDebut);
            ParamModel.Add("DateFin", DateFin);
            Response.Add("ParamModel", ParamModel);


            return Request.CreateResponse(HttpStatusCode.OK, Response);
        }


        public HttpResponseMessage DialogueSecuriteStatistiqueFiltered(StatistiquePyramideParamModel statistiquePyramideParamModel)
        {

            //Dictionary<string, string> DataTableParameters = new Dictionary<string, string>();
            //DataTableParameters = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            DateTime ParameterDateDebut = statistiquePyramideParamModel.DateDebut;
            DateTime ParameterDateFin = statistiquePyramideParamModel.DateFin;

            DateTime DateDebut = ParameterDateDebut;
            DateTime DateFin = ParameterDateFin.AddDays(+1);

            var queryDialogueSecurite = from d in db.DialogueSecurites
                                     where d.Date >= DateDebut
                                     && d.Date <= DateFin
                                       select new DialogueSecuriteStatistique
                                       {
                                           Id = d.Id,
                                           Date = d.Date,
                                           SiteId = d.SiteId,
                                           Site = d.Site.Trigramme,
                                           ZoneId = d.ZoneId,
                                           Dialogueur1Id = d.Dialogueur1Id,
                                           Dialogueur2Id = d.Dialogueur2Id,
                                           Dialogueur3Id = d.Dialogueur3Id,
                                           Entretenu1Id = d.Entretenu1Id,
                                           Entretenu2Id = d.Entretenu2Id,
                                           Entretenu3Id = d.Entretenu3Id,
                                           Dialogueur1 = d.Dialogueur1,
                                           Dialogueur2 = d.Dialogueur2,
                                           Dialogueur3 = d.Dialogueur3,
                                           Entretenu1 = d.Entretenu1,
                                           Entretenu2 = d.Entretenu2,
                                           Entretenu3 = d.Entretenu3
                                       };

            var AllDialogueSecurite = queryDialogueSecurite.ToList();

            foreach (var DS in AllDialogueSecurite)
            {
                DS.TimeStamp = (Int32)(DS.Date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Response.Add("AllDialogueSecurite", AllDialogueSecurite);


            return Request.CreateResponse(HttpStatusCode.OK, AllDialogueSecurite);
        }





    }
}

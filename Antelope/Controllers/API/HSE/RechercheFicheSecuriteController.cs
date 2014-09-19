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
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;



namespace Antelope.Controllers.API.HSE
{
    public class RechercheFicheSecuriteController : ApiController
    {

        private AntelopeContext db = new AntelopeContext();
        public FicheSecuriteRepository _ficheSecuriteRepository { get; set; }



        // GET: api/RechercheFicheSecurite
        public HttpResponseMessage Get()
        {

            // TODO A METTRE DANS UN "ANNUAIRE REPOSITORY" 
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "refresco.local"); //"refresco.local" > Pas obligatoire ?
            UserPrincipal user = UserPrincipal.Current;
            DirectoryEntry de = user.GetUnderlyingObject() as DirectoryEntry;
            String userCompanyName = (String)de.Properties["company"].Value;
            
            _ficheSecuriteRepository = new FicheSecuriteRepository();

            var queryPersonneConnectee = from p in db.Personnes
                    where p.GUID == user.Guid
                    select p;
            Personne PersonneConnectee = (Personne)queryPersonneConnectee.SingleOrDefault();

            var querySiteUser = from s in db.Sites
                                             where s.Trigramme == userCompanyName
                                             select s;
            Site SiteUser = (Site)querySiteUser.SingleOrDefault();

            // TODO ZONEREPOSITORY
            var queryZone = from a in db.Zones
                            where a.SiteId == SiteUser.SiteID
                            select a;
            List<Zone> AllZone = queryZone.ToList();

            // TODO LIEUREPOSITORY
            List<Lieu> AllLieu = new List<Lieu>();

            // TODO POSTEDETRAVAILREPOSITORY
            List<PosteDeTravail> AllPosteDeTravail = new List<PosteDeTravail>();

            // TODO SERVICEREPOSITORY
            var queryService = from a in db.Services
                               where a.SiteId == SiteUser.SiteID
                               select a;
            List<Service> AllService = queryService.ToList();

            RechercheFicheSecuriteParamModel RechercheFicheSecuriteParamModel = new RechercheFicheSecuriteParamModel()
            {
                SiteId = SiteUser.SiteID,
                ZoneId = 0,
                LieuId = 0,
                FicheSecuriteTypeId = 0,
                Code = "",
                Age = "",
                PosteDeTravailId = 0,
                ServiceId = 0,
                DateEvenementDebut = new DateTime(2014, 01, 01),
                DateEvenementFin = new DateTime(2020, 12, 31),
                PersonneConcerneeNom = "",
                ResponsableNom = user.Surname,
                ResponsableGuid = user.Guid,
                CotationFrequence = null,
                CotationGravite = null,
                RisqueId = 0,
                DangerId = 0,
                CorpsHumainZoneId = 0,
                PlageHoraireId = 0

            };

            List<FicheSecurite> AllFicheSecurite = _ficheSecuriteRepository.GetFromParams(RechercheFicheSecuriteParamModel);

            RechercheFicheSecuriteViewModel RechercheFicheSecuriteViewModel = new RechercheFicheSecuriteViewModel(RechercheFicheSecuriteParamModel,AllFicheSecurite, AllService, AllZone, AllLieu, AllPosteDeTravail);

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
            if (RechercheFicheSecuriteParamModel.FicheSecuriteTypeId != null && RechercheFicheSecuriteParamModel.FicheSecuriteTypeId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecuriteTypeId == RechercheFicheSecuriteParamModel.FicheSecuriteTypeId);
            }
            if (RechercheFicheSecuriteParamModel.Code != null && RechercheFicheSecuriteParamModel.Code != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Code == RechercheFicheSecuriteParamModel.Code);
            }
            if (RechercheFicheSecuriteParamModel.Age != null && RechercheFicheSecuriteParamModel.Age != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Age == RechercheFicheSecuriteParamModel.Age);
            }
            if (RechercheFicheSecuriteParamModel.PosteDeTravailId != null && RechercheFicheSecuriteParamModel.PosteDeTravailId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PosteDeTravailId == RechercheFicheSecuriteParamModel.PosteDeTravailId);
            }
            if (RechercheFicheSecuriteParamModel.ServiceId != null && RechercheFicheSecuriteParamModel.ServiceId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.ServiceId == RechercheFicheSecuriteParamModel.ServiceId);
            }
            if (RechercheFicheSecuriteParamModel.DateEvenementDebut != null)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement >= RechercheFicheSecuriteParamModel.DateEvenementDebut);
            }
            if (RechercheFicheSecuriteParamModel.DateEvenementFin != null)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement <= RechercheFicheSecuriteParamModel.DateEvenementFin);
            }
            if (RechercheFicheSecuriteParamModel.PersonneConcerneeNom != null && RechercheFicheSecuriteParamModel.PersonneConcerneeNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PersonneConcernee.Nom == RechercheFicheSecuriteParamModel.PersonneConcerneeNom);
            }
            if (RechercheFicheSecuriteParamModel.ResponsableNom != null && RechercheFicheSecuriteParamModel.ResponsableNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.Nom == RechercheFicheSecuriteParamModel.ResponsableNom);
            }
            if (RechercheFicheSecuriteParamModel.CotationFrequence != null && RechercheFicheSecuriteParamModel.CotationFrequence != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence == RechercheFicheSecuriteParamModel.CotationFrequence);
            }
            if (RechercheFicheSecuriteParamModel.CotationGravite != null && RechercheFicheSecuriteParamModel.CotationGravite != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationGravite == RechercheFicheSecuriteParamModel.CotationGravite);
            }
            if (RechercheFicheSecuriteParamModel.RisqueId != null && RechercheFicheSecuriteParamModel.RisqueId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.RisqueId == RechercheFicheSecuriteParamModel.RisqueId);
            }
            if (RechercheFicheSecuriteParamModel.DangerId != null && RechercheFicheSecuriteParamModel.DangerId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DangerId == RechercheFicheSecuriteParamModel.DangerId);
            }
            if (RechercheFicheSecuriteParamModel.CorpsHumainZoneId != null && RechercheFicheSecuriteParamModel.CorpsHumainZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CorpsHumainZoneId == RechercheFicheSecuriteParamModel.CorpsHumainZoneId);
            }
            if (RechercheFicheSecuriteParamModel.PlageHoraireId != null && RechercheFicheSecuriteParamModel.PlageHoraireId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PlageHoraireId == RechercheFicheSecuriteParamModel.PlageHoraireId);
            }
            if (RechercheFicheSecuriteParamModel.ResponsableGuid != null && RechercheFicheSecuriteParamModel.ResponsableGuid != new Guid())
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.GUID == RechercheFicheSecuriteParamModel.ResponsableGuid);
            }





            List<FicheSecurite> AllFicheSecurite = queryFicheSecurite.ToList();
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

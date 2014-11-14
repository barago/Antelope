using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Repositories.Socle;
using Antelope.ViewModels.QSE.NonConformiteViewModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.QSE
{
    public class RechercheNonConformiteController : ApiController
    {

        private AntelopeEntities db = new AntelopeEntities();
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }


        // GET: api/RechercheNonConformite
        public HttpResponseMessage Get()
        {

            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();

            UserPrincipal user = _activeDirectoryUtilisateurRepository.GetActiveDirectoryUser(System.Web.HttpContext.Current.User.Identity.Name.Split('\\')[1]);

            String SiteTrigramme = _activeDirectoryUtilisateurRepository.GetCurrentUserSiteTrigramme();

            //_ficheSecuriteRepository = new FicheSecuriteRepository();

            var queryPersonneConnectee = from p in db.Personnes
                                         where p.Guid == user.Guid
                                         select p;
            Personne PersonneConnectee = (Personne)queryPersonneConnectee.SingleOrDefault();

            var querySiteUser = from s in db.Sites
                                where s.Trigramme == SiteTrigramme
                                select s;
            Site SiteUser = (Site)querySiteUser.SingleOrDefault();


            RechercheNonConformiteParamModel RechercheNonConformiteParamModel = new RechercheNonConformiteParamModel()
            {
                SiteId = SiteUser.SiteID,
                NonConformiteDomaineId = 0,
                NonConformiteGraviteId = 0,
                NonConformiteOrigineId = 0
            };

            //NonConformitePaginatedList FicheSecuritePaginatedList = _nonConformiteRepository.GetFromParams(RechercheNonConformiteParamModel);

            RechercheNonConformiteViewModel RechercheFicheSecuriteViewModel = new RechercheNonConformiteViewModel(RechercheNonConformiteParamModel);

            return Request.CreateResponse(HttpStatusCode.OK, RechercheFicheSecuriteViewModel);
        }



    }
}

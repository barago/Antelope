using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Repositories.Socle;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.Services
{
    public class AnnuaireController : ApiController
    {

        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }
        private AntelopeEntities db = new AntelopeEntities();

        public HttpResponseMessage GetAnnuaire()
        {

            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();

            String SiteTrigramme = _activeDirectoryUtilisateurRepository.GetCurrentUserSiteTrigramme();

            var querySiteUser = from s in db.Sites
                                where s.Trigramme == SiteTrigramme
                                select s;
            Site SiteUser = (Site)querySiteUser.SingleOrDefault();

            var SiteId = SiteUser.SiteID;

            var AllSite = db.Sites;

            //var AllUtilisateur;

            var context = new PrincipalContext(ContextType.Domain, "refresco.local"); //"refresco.local" > Pas obligatoire ?
            //define a "query-by-example" principal - here, we search for a UserPrincipal 
            //and with the first name (GivenName) and a last name (Surname) 
            UserPrincipal qbeUser = new UserPrincipal(context);

            PrincipalSearcher ps = new PrincipalSearcher(qbeUser);
            ((DirectorySearcher)ps.GetUnderlyingSearcher()).Filter = "(&(objectCategory=Person)(objectClass=User)(company='RFS'))";

            foreach (var result in ps.FindAll())
            {
                var a = 1;

            }

            //DirectoryEntry de = qbeUser.GetUnderlyingObject() as DirectoryEntry;
            //de.Properties["company"].Value = "RFS";

            return Request.CreateResponse(HttpStatusCode.OK);
        }




    }
}

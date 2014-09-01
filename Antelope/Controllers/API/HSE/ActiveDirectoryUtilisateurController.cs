using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Antelope.Models;
using Antelope.Models.Socle;
using Antelope.ViewModels.Socle.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace Antelope.Controllers.API.HSE
{
    public class ActiveDirectoryUtilisateurController : ApiController
    {
        private AntelopeContext db = new AntelopeContext();



        public HttpResponseMessage GetActiveDirectoryUtilisateurByNomPrenom(int id, string param1, string param2)  // [FromUri] ActiveDirectoryUtilisateurViewModel activeDirectoryUtilisateurViewModel
        {

            var a = 0;

            List<ActiveDirectoryUtilisateurViewModel> allActiveDirectoryViewModel = new List<ActiveDirectoryUtilisateurViewModel>();


            var context = new PrincipalContext(ContextType.Domain, "refresco.local");
            // define a "query-by-example" principal - here, we search for a UserPrincipal 
            // and with the first name (GivenName) and a last name (Surname) 
            UserPrincipal qbeUser = new UserPrincipal(context);

            if(param2 != "undefined"){
                qbeUser.GivenName = "*" + param2 + "*";
            }
            if (param1 != "undefined")
            {
                qbeUser.Surname = "*" + param1 + "*";
            }

            // create your principal searcher passing in the QBE principal    
            PrincipalSearcher srch = new PrincipalSearcher(qbeUser);

            // find all matches
            foreach (var result in srch.FindAll())
            {
                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                System.Diagnostics.Debug.WriteLine("First Name: " + de.Properties["givenName"].Value + " " + "Last Name : " + de.Properties["sn"].Value);

                allActiveDirectoryViewModel.Add(
                    new ActiveDirectoryUtilisateurViewModel
                    {
                        Nom = (string)de.Properties["sn"].Value,
                        Prenom = (string)de.Properties["givenName"].Value,
                        Guid = (Guid)result.Guid
                    }
                );

            }


            return Request.CreateResponse(HttpStatusCode.OK, allActiveDirectoryViewModel);
        }

    }
}
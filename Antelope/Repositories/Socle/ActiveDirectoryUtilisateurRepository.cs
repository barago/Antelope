using Antelope.DTOs.Socle;
using Antelope.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.DirectoryServices;


namespace Antelope.Repositories.Socle
{
    public class ActiveDirectoryUtilisateurRepository
    {

        public AntelopeContext _db { get; set; }
        public PrincipalContext _principalContext { get; set; }

        public ActiveDirectoryUtilisateurRepository()
            : this(new AntelopeContext(), new PrincipalContext(ContextType.Domain, "refresco.local"))
        {

        }

        public ActiveDirectoryUtilisateurRepository(AntelopeContext db, PrincipalContext principalContext)
        {
            _db = db;
            _principalContext = principalContext;
        }

        public ActiveDirectoryUtilisateurDTO GetActiveDirectoryUtilisateurByNomPrenom(String Nom, String Prenom)
        {
            UserPrincipal qbeUser = new UserPrincipal(_principalContext);

            qbeUser.GivenName = Prenom;
            qbeUser.Surname = Nom;

            PrincipalSearcher srch = new PrincipalSearcher(qbeUser);
            Principal principal = srch.FindOne();
            var utilisateurAD = principal.GetUnderlyingObject() as DirectoryEntry; 


            ActiveDirectoryUtilisateurDTO ActiveDirectoryUtilisateurDTO = new ActiveDirectoryUtilisateurDTO()
            {
                Guid = (Guid)principal.Guid,
                Nom = (string)utilisateurAD.Properties["sn"].Value,
                Prenom = (string)utilisateurAD.Properties["givenName"].Value
            };

            return ActiveDirectoryUtilisateurDTO;
        }






    }
}
using Antelope.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Repositories.Socle
{
    public class ActiveDirectoryUtilisateurRepository
    {

        public AntelopeContext _db { get; set; }

        public ActiveDirectoryUtilisateurRepository() : this(new AntelopeContext())
        {

        }

        public ActiveDirectoryUtilisateurRepository(AntelopeContext db)
        {
            _db = db;
        }

        public FicheSecurite Get(int id)
        {
            FicheSecurite ficheSecurite = _db.FicheSecurites.SingleOrDefault(r => r.FicheSecuriteID == id);
            return ficheSecurite;
        }






    }
}
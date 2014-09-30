using Antelope.Models;
using Antelope.Models.Socle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Repositories.Socle
{
    public class PersonneRepository
    {

        public AntelopeContext _db { get; set; }

        public PersonneRepository() : this(new AntelopeContext())
        {

        }

        public PersonneRepository(AntelopeContext db)
        {
            _db = db;
        }

        public Personne GetPersonneByNomPrenom(string Nom, string Prenom)
        {
            var queryPersonne = from p in _db.Personnes
                                where p.Nom == Nom
                                && p.Prenom == Prenom
                                select p;
            Personne personne = queryPersonne.SingleOrDefault();
            return personne;
        }




    }
}
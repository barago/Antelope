using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.QSE.NonConformiteViewModels
{
    public class NonConformiteViewModel
    {
        private AntelopeEntities db = new AntelopeEntities();

        public NonConformite NonConformite;
        public List<NonConformiteOrigine> AllNonConformiteOrigine;
        public List<NonConformiteDomaine> AllNonConformiteDomaine;
        public List<NonConformiteGravite> AllNonConformiteGravite;
        public List<Site> AllSite;

        public NonConformiteViewModel(NonConformite nonConformite)
        {
            this.NonConformite = nonConformite;
            this.AllNonConformiteDomaine = db.NonConformiteDomaines.OrderBy(o => o.Nom).ToList();
            this.AllNonConformiteOrigine = db.NonConformiteOrigines.OrderBy(o=>o.Nom).ToList();
            this.AllNonConformiteGravite = db.NonConformiteGravites.ToList(); 
            this.AllSite = db.Sites.ToList();
        }

    }
}
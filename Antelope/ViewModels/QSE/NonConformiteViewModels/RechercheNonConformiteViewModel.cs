﻿using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.QSE.NonConformiteViewModels
{
    public class RechercheNonConformiteViewModel
    {

        private AntelopeEntities db = new AntelopeEntities();

        //public NonConformitePaginatedList FicheSecuritePaginatedList;

        public List<Site> AllSite;
        public List<NonConformiteDomaine> AllNonConformiteDomaine;
        public List<NonConformiteOrigine> AllNonConformiteOrigine;
        public List<NonConformiteGravite> AllNonConformiteGravite;

        public RechercheNonConformiteParamModel RechercheNonConformiteParamModel;


        public RechercheNonConformiteViewModel(RechercheNonConformiteParamModel rechercheNonConformiteParamModel)
        {
            this.AllSite = db.Sites.ToList();
            this.AllNonConformiteDomaine = db.NonConformiteDomaines.ToList();
            this.AllNonConformiteOrigine = db.NonConformiteOrigines.ToList();
            this.AllNonConformiteGravite = db.NonConformiteGravites.ToList();

            this.RechercheNonConformiteParamModel = rechercheNonConformiteParamModel;
        }

    }


}
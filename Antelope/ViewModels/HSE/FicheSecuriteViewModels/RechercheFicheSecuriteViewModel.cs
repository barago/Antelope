﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antelope.Models.HSE;
using Antelope.Models.Socle;
using Antelope.Models;
using Antelope.Repositories.HSE;


namespace Antelope.ViewModels.HSE.FicheSecuriteViewModels
{
    public class RechercheFicheSecuriteViewModel
    {



        private AntelopeContext db = new AntelopeContext();

        public List<FicheSecurite> AllFicheSecurite;
        public List<Zone> AllZone;
        public List<Lieu> AllLieu;
        public List<Site> AllSite;
        public List<Service> AllService;
        public List<PosteDeTravail> AllPosteDeTravail;
        public List<FicheSecuriteType> AllFicheSecuriteType;
        public List<Danger> AllDanger;
        public List<PlageHoraire> AllPlageHoraire;
        public List<CorpsHumainZone> AllCorpsHumainZone;
        public List<RisqueType> AllRisqueType;
        public List<Risque> AllRisque;
        public String FicheSecuriteDate;
        public String FicheSecuriteHeure;
        public RechercheFicheSecuriteParamModel RechercheFicheSecuriteParamModel;

        public RechercheFicheSecuriteViewModel()
        {


            this.AllZone = new List<Zone>();
            this.AllLieu = new List<Lieu>();
            this.AllSite = db.Sites.ToList(); // new List<Site>();
            this.AllFicheSecuriteType = db.FicheSecuriteTypes.ToList();
            this.AllDanger = db.Dangers.ToList();
            this.AllPlageHoraire = db.PlageHoraires.ToList();
            this.AllRisqueType = db.RisqueTypes.ToList();
            this.AllRisque = db.Risques.ToList();
        }

        public RechercheFicheSecuriteViewModel(
                                        RechercheFicheSecuriteParamModel RechercheFicheSecuriteParamModel,
                                        List<FicheSecurite> AllFicheSecurite, 
                                        List<Service> AllService, 
                                        List<Zone> AllZone, 
                                        List<Lieu> AllLieu, 
                                        List<PosteDeTravail> AllPosteDeTravail
        )
        {

            this.AllFicheSecurite = AllFicheSecurite;
            this.RechercheFicheSecuriteParamModel = RechercheFicheSecuriteParamModel;
            this.AllZone = AllZone;
            this.AllLieu = AllLieu;
            this.AllPosteDeTravail = AllPosteDeTravail;
            this.AllSite = db.Sites.ToList(); // new List<Site>();
            this.AllFicheSecuriteType = db.FicheSecuriteTypes.ToList();
            this.AllDanger = db.Dangers.ToList();
            this.AllPlageHoraire = db.PlageHoraires.ToList();
            this.AllCorpsHumainZone = db.CorpsHumainZones.ToList();
            this.AllRisqueType = db.RisqueTypes.ToList();
            this.AllRisque = db.Risques.ToList();
            this.AllService = AllService;

        }

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antelope.Models.HSE;
using Antelope.Models.Socle;
using Antelope.Models;


namespace Antelope.ViewModels.HSE.FicheSecuriteViewModels
{

    public class FicheSecuriteViewModel
    {

        private AntelopeContext db = new AntelopeContext();

        public FicheSecurite FicheSecurite;
        public List<Zone> AllZone;
        public List<Lieu> AllLieu;
        public List<Site> AllSite;
        public List<FicheSecuriteType> AllFicheSecuriteType;
        public List<Danger> AllDanger;
        public List<PlageHoraire> AllPlageHoraire;

        public FicheSecuriteViewModel()
        {

            this.FicheSecurite = new FicheSecurite();
            this.AllZone = new List<Zone>();
            this.AllLieu = new List<Lieu>();
            this.AllSite = db.Sites.ToList(); // new List<Site>();
            this.AllFicheSecuriteType = db.FicheSecuriteTypes.ToList();
            this.AllDanger = db.Dangers.ToList();
            this.AllPlageHoraire = db.PlageHoraires.ToList();

        }

        public FicheSecuriteViewModel(FicheSecurite ficheSecurite)
        {

            this.FicheSecurite = ficheSecurite;
            this.AllZone = new List<Zone>();
            this.AllLieu = new List<Lieu>();
            this.AllSite = db.Sites.ToList(); // new List<Site>();
            this.AllFicheSecuriteType = db.FicheSecuriteTypes.ToList();
            this.AllDanger = db.Dangers.ToList();
            this.AllPlageHoraire = db.PlageHoraires.ToList();

        }

    }
}
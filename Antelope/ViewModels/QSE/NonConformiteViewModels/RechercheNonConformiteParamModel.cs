﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.QSE.NonConformiteViewModels
{
    public class RechercheNonConformiteParamModel
    {

        //TODO : Certainement à reclassifier en DTO : RechercheNonConformiteDTOModel
        public Int32? SiteId { get; set; }
        public Int32? NonConformiteOrigineId { get; set; }
        public Int32? NonConformiteGraviteId { get; set; }
        public Int32? NonConformiteDomaineId { get; set; }
        public String ResponsableNom { get; set; }
        public String VerificateurNom { get; set; }

       // public RechercheNonConformiteParamModel rechercheNonConformiteParamModel{ get; set;}

        public DateTime? DateButoirDebut { get; set; }
        public DateTime? DateButoirFin { get; set; }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.HSE.FicheSecuriteViewModels
{
    public class RechercheFicheSecuriteParamModel
    {

        public Int32? SiteId { get; set; }
        public Int32? ZoneId { get; set; }
        public Int32? LieuId { get; set; }
        public Int32? FicheSecuriteTypeId { get; set; }
        public String Code { get; set; }
        public String Age { get; set; }
        public Int32? PosteDeTravailId { get; set; }
        public Int32? ServiceId { get; set; }
        public DateTime? DateEvenementDebut { get; set; }
        public DateTime? DateEvenementFin { get; set; }
        public String PersonneConcerneeNom { get; set; }
        public String ResponsableNom { get; set; }
        public short? CotationFrequence { get; set; }
        public short? CotationGravite { get; set; }
        public Int32? RisqueId { get; set; }
        public Int32? DangerId { get; set; }
        public Int32? CorpsHumainZoneId { get; set; }
        public Int32? PlageHoraireId { get; set; }
        public Guid? ResponsableGuid { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
    }
}
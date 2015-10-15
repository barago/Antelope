//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Antelope.Domain.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class FicheSecurite
    {
        public FicheSecurite()
        {
            //this.ActionSecurites = new HashSet<ActionSecurite>();
            this.CauseQSEs = new HashSet<CauseQSE>();
        }
    
        public int FicheSecuriteID { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Age { get; set; }
        public Nullable<int> PosteDeTravailId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public System.DateTime DateCreation { get; set; }
        public System.DateTime DateEvenement { get; set; }
        public string PersonnesConcernees { get; set; }
        public string Description { get; set; }
        public string ActionImmediate1 { get; set; }
        public string ActionImmediate2 { get; set; }
        public string Temoins { get; set; }
        public short CotationFrequence { get; set; }
        public short CotationGravite { get; set; }
        public int FicheSecuriteTypeId { get; set; }
        public int RisqueId { get; set; }
        public int DangerId { get; set; }
        public int CorpsHumainZoneId { get; set; }
        public Nullable<int> PlageHoraireId { get; set; }
        public int SiteId { get; set; }
        public Nullable<int> ZoneId { get; set; }
        public Nullable<int> LieuId { get; set; }
        public bool EnqueteRealisee { get; set; }
        public Nullable<System.DateTime> EnqueteDate { get; set; }
        public string EnqueteProtagoniste { get; set; }
        public string CHSCTMembre { get; set; }
        public Nullable<int> PersonneConcerneeId { get; set; }
        public Nullable<int> ResponsableId { get; set; }
        public bool WorkFlowDiffusee { get; set; }
        public bool WorkFlowAttenteASEValidation { get; set; }
        public bool WorkFlowASEValidee { get; set; }
        public bool WorkFlowASERejetee { get; set; }
        public bool WorkFlowCloturee { get; set; }
        public string WorkFlowASERejeteeCause { get; set; }
        public bool WorkFlowFicheSecuriteCloturee { get; set; }
        public int CompteurAnnuelSite { get; set; }

    
        //public virtual ICollection<ActionSecurite> ActionSecurites { get; set; }
        
        public virtual ICollection<CauseQSE> CauseQSEs { get; set; }
        [JsonIgnore]
        public virtual ICollection<FilePath> FilePaths { get; set; }
        [JsonIgnore]
        public virtual CorpsHumainZone CorpsHumainZone { get; set; }
        [JsonIgnore]
        public virtual Danger Danger { get; set; }
        [JsonIgnore] 
        public virtual FicheSecuriteType FicheSecuriteType { get; set; }
        [JsonIgnore]
        public virtual Lieu Lieu { get; set; }
        public virtual Personne PersonneConcernee { get; set; }
        public virtual Personne Responsable { get; set; }
        [JsonIgnore]
        public virtual PlageHoraire PlageHoraire { get; set; }
        [JsonIgnore]
        public virtual PosteDeTravail PosteDeTravail { get; set; }
        [JsonIgnore]
        public virtual Risque Risque { get; set; }
        [JsonIgnore]
        public virtual Service Service { get; set; }
        [JsonIgnore]
        public virtual Site Site { get; set; }
        [JsonIgnore]
        public virtual Zone Zone { get; set; }
    }
}

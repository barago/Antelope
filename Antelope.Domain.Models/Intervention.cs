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
    using System;
    using System.Collections.Generic;
    
    public partial class Intervention
    {
        public int InterventionID { get; set; }
        public string Intervenant { get; set; }
        public string DateIntervention { get; set; }
        public bool Planifie { get; set; }
        public string Demandeur { get; set; }
        public string Motif { get; set; }
        public int DureeIntervention { get; set; }
        public bool NoteFrais { get; set; }
        public float PrimeIntervention { get; set; }
        public float PrimeDimanche { get; set; }
        public bool Valide { get; set; }
    }
}

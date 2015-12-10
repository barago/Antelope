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
    
    public partial class Lieu
    {
        public Lieu()
        {
            this.FicheSecurites = new HashSet<FicheSecurite>();
        }
    
        public int LieuID { get; set; }
        public int ZoneId { get; set; }
        public int LieuTypeId { get; set; }
        public string Nom { get; set; }
        public int Rang { get; set; }

        [JsonIgnore]
        public virtual ICollection<FicheSecurite> FicheSecurites { get; set; }
        [JsonIgnore]
        public virtual ICollection<DialogueSecurite> DialogueSecurites { get; set; }
        [JsonIgnore]
        public virtual Zone Zone { get; set; }
    }
}

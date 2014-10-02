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
    
    public partial class Site
    {
        public Site()
        {
            this.FicheSecurites = new HashSet<FicheSecurite>();
            this.Services = new HashSet<Service>();
            this.Zones = new HashSet<Zone>();
        }
    
        public int SiteID { get; set; }
        public string Nom { get; set; }
        public string Trigramme { get; set; }
        public string Arouperr { get; set; }

        [JsonIgnore]
        public virtual ICollection<FicheSecurite> FicheSecurites { get; set; }
        [JsonIgnore]
        public virtual ICollection<Service> Services { get; set; }
        [JsonIgnore]
        public virtual ICollection<Zone> Zones { get; set; }
    }
}

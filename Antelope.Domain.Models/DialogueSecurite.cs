using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antelope.Domain.Models
{
    public class DialogueSecurite
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Contexte {get; set;}
        public string Observation {get; set;}
        public string Reflexion { get; set; }
        public string Action {get; set;}
        public string Atelier {get ;set;}
        public int SiteId { get; set;}
        public int CompteurAnnuelSite { get; set; }
        public string Code { get; set; }

        [JsonIgnore]
        public virtual Site Site { get; set; }
    }
}

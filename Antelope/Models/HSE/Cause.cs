using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antelope.Models.HSE
{
    public class Cause
    {

        public Int32 CauseID { get; set; }

        public string Description { get; set; }

        [DisplayName("Fiche Sécurité")]
        public Int32 FicheSecuriteId { get; set; }

        [JsonIgnore]
        public virtual FicheSecurite FicheSecurite { get; set; }


    }
}
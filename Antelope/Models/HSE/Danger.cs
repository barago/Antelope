using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Models.HSE
{
    public class Danger
    {
        public Int32 DangerID { get; set; }

        public string Nom { get; set; }

        // Virtual = Lazy Loading
        public virtual List<FicheSecurite> FicheSecurites { get; set; }

    }
}
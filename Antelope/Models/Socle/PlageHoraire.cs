using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antelope.Models.HSE;

namespace Antelope.Models.Socle
{
    public class PlageHoraire
    {

        public Int32 PlageHoraireID { get; set; }

        public string Nom { get; set; }

        // Virtual = Lazy Loading
        public virtual List<FicheSecurite> FicheSecurites { get; set; }
    }
}
using Antelope.Models.HSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Models.Socle
{
    public class Lieu
    {

        public Int32 LieuID { get; set; }

        public String Nom { get; set; }

        public virtual List<FicheSecurite> FicheSecurites { get; set; }

        public Int32 ZoneId { get; set; }
        public virtual Zone Zone{ get; set; }

    }
}
﻿using Antelope.Models.HSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Models.Socle
{
    public class Zone
    {

        public Int32 ZoneID { get; set; }

        public String Nom { get; set; }

        public virtual List<FicheSecurite> FicheSecurites { get; set; }

        public Int32 SiteId { get; set; }
        public virtual Site Site { get; set; }
    }
}
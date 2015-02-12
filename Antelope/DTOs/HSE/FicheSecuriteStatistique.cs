using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.DTOs.HSE
{
    public class FicheSecuriteStatistique
    {
        public Int32 Id { get; set; }
        public DateTime DateEvnmt { get; set; }
        public String Site { get; set; }
        public Int32 TimeStamp { get; set; }

        public virtual ICollection<CauseQSE> CauseQSEs { get; set; }
    }
}


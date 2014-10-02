using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Services.HSE
{
    public class FicheSecuriteServices
    {

        public static void AddTriParamsToViewBag(dynamic viewBag, String ordreTri)
        {
            viewBag.TriParametreCode = String.IsNullOrEmpty(ordreTri) ? "Code_desc" : "";
            viewBag.TriParametreType = ordreTri == "Type" ? "Type_desc" : "Type";
        }


        public static IQueryable<FicheSecurite> TriFicheSecurites(IQueryable<FicheSecurite> ficheSecurites, string ordreTri)
        {

            switch (ordreTri)
            {
                case "Code_desc":
                    ficheSecurites = ficheSecurites.OrderByDescending(f => f.Code);
                    break;
                case "Type":
                    ficheSecurites = ficheSecurites.OrderBy(f => f.Type);
                    break;
                case "Type_desc":
                    ficheSecurites = ficheSecurites.OrderByDescending(f => f.Type);
                    break;
                default:
                    ficheSecurites = ficheSecurites.OrderBy(f => f.Code);
                    break;
            }

            return ficheSecurites;
        }

    }

}
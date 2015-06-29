using Antelope.Domain.Models;
using Antelope.DTOs.QSE;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.Socle.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Repositories.QSE
{
    public class NonConformiteRepository
    {

        public AntelopeEntities _db { get; set; }

        public NonConformiteRepository() : this(new AntelopeEntities())
        {

        }

        public NonConformiteRepository(AntelopeEntities db)
        {
            _db = db;
        }

        public NonConformite Get(Int32 id)
        {
            NonConformite NonConformite = _db.NonConformites.SingleOrDefault(r => r.Id == id);
            return NonConformite;
        }

        public DataTableViewModel<NonConformite> GetFromParams(Dictionary<string, string> DataTableParameters)
        {

            Int32 ParameterStart = Int32.Parse(DataTableParameters["start"]);
            Int32 ParameterLength = Int32.Parse(DataTableParameters["length"]);
            Int32 ParameterSiteId = Int32.Parse(DataTableParameters["siteId"]);
            Int32 ParameterOrigineId = Int32.Parse(DataTableParameters["nonConformiteOrigineId"]);
            Int32 ParameterGraviteId = Int32.Parse(DataTableParameters["nonConformiteGraviteId"]);
            Int32 ParameterDomaineId = Int32.Parse(DataTableParameters["nonConformiteDomaineId"]);

            String ParameterResponsableNom = DataTableParameters["responsableNom"];
            DateTime? ParameterDateButoirDebut = null;
            DateTime? ParameterDateButoirFin = null;

            if (DataTableParameters["dateButoirDebut"] != "")
            {
                try
                {
                    ParameterDateButoirDebut = DateTime.Parse(DataTableParameters["dateButoirDebut"]);
                }
                catch (Exception e)
                {

                }
            }
            if (DataTableParameters["dateButoirFin"] != "")
            {
                try
                {
                    ParameterDateButoirFin = DateTime.Parse(DataTableParameters["dateButoirFin"]);
                }
                catch (Exception e)
                {

                }
            }


            //var queryNonConformite = from nc in _db.NonConformites
            //                        join a in _db.ActionQSEs on nc.Id equals a.NonConformiteId
            //                        orderby nc.Id
            //                        select new NonConformiteActionRecherche(){NonConformite =nc, ActionQSE = a};

            var queryNonConformite = from nc in _db.NonConformites
                                     //orderby nc.Id
                                     select nc;


            if (ParameterSiteId != null && ParameterSiteId != 0)
            {
                queryNonConformite = queryNonConformite.Where(q => q.SiteId == ParameterSiteId);
            }
            if (ParameterOrigineId != null && ParameterOrigineId != 0)
            {
                queryNonConformite = queryNonConformite.Where(q => q.NonConformiteOrigineId == ParameterOrigineId);
            }
            if (ParameterGraviteId != null && ParameterGraviteId != 0)
            {
                queryNonConformite = queryNonConformite.Where(q => q.NonConformiteGraviteId == ParameterGraviteId);
            }
            if (ParameterDomaineId != null && ParameterDomaineId != 0)
            {
                queryNonConformite = queryNonConformite.Where(q => q.NonConformiteDomaineId == ParameterDomaineId);
            }
            if (ParameterResponsableNom != null && ParameterResponsableNom != "")
            {
                //queryNonConformite = queryNonConformite.Where(q => q.Responsable.Nom == ParameterResponsableNom);

                queryNonConformite = queryNonConformite
                .Join(_db.ActionQSEs, nc => nc.Id, a => a.NonConformiteId, (nc, a) => new { NonConformite = nc, ActionQSE = a })
                .Where(j => j.ActionQSE.Responsable.Nom == ParameterResponsableNom)
                .Select(q => q.NonConformite)
                .Distinct();

                //queryNonConformite = queryNonConformite
                //    .Where(w => w.ActionQSE.Responsable.Nom == ParameterResponsableNom);
            }


            int RecordsFiltered = queryNonConformite.Count();
            int RecordsTotal = _db.NonConformites.Count();

            queryNonConformite = queryNonConformite.OrderBy(i => i.Id);

            if (ParameterLength != -1)
            {
                queryNonConformite = queryNonConformite.Skip(ParameterStart).Take(ParameterLength);
            }

            var AllNonConformite = queryNonConformite.ToList();

            DataTableViewModel<NonConformite> DataTableViewModel = new DataTableViewModel<NonConformite>()
            {
                recordsTotal = RecordsTotal,
                recordsFiltered = RecordsFiltered,
                data = AllNonConformite
            };


            return DataTableViewModel;

        }



    }
}
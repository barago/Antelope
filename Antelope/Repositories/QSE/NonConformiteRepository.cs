using Antelope.Domain.Models;
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

            IQueryable<NonConformite> queryNonConformite = from nc in _db.NonConformites
                                                           orderby nc.Id
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

            int RecordsFiltered = queryNonConformite.Count();
            int RecordsTotal = _db.NonConformites.Count();

            queryNonConformite = queryNonConformite.Skip(ParameterStart).Take(ParameterLength);

            List<NonConformite> AllNonConformite = queryNonConformite.ToList();

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
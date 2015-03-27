using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.Socle.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Repositories.QSE
{
    public class ActionQSERepository
    {

        public AntelopeEntities _db { get; set; }

        public ActionQSERepository() : this(new AntelopeEntities())
        {

        }

        public ActionQSERepository(AntelopeEntities db)
        {
            _db = db;
        }

        public ActionQSE Get(Int32 id)
        {
            ActionQSE ActionQSE = _db.ActionQSEs.SingleOrDefault(r => r.ActionQSEId == id);
            return ActionQSE;
        }

        public DataTableViewModel<ActionQSE> GetFromParams(Dictionary<string, string> DataTableParameters)
        {

            Int32 ParameterStart = Int32.Parse(DataTableParameters["start"]);
            Int32 ParameterLength = Int32.Parse(DataTableParameters["length"]);
            Int32 ParameterSiteId = Int32.Parse(DataTableParameters["siteId"]);
            Int32 ParameterOrigineId = Int32.Parse(DataTableParameters["nonConformiteOrigineId"]);
            Int32 ParameterGraviteId = Int32.Parse(DataTableParameters["nonConformiteGraviteId"]);
            Int32 ParameterDomaineId = Int32.Parse(DataTableParameters["nonConformiteDomaineId"]);

            IQueryable<ActionQSE> queryActionQSE = from a in _db.ActionQSEs
                                                           orderby a.ActionQSEId
                                                           select a;

            queryActionQSE = queryActionQSE.Where(q => q.NonConformiteId != null);

            if (ParameterSiteId != null && ParameterSiteId != 0)
            {
                queryActionQSE = queryActionQSE.Where(q => q.NonConformite.SiteId == ParameterSiteId);
            }
            if (ParameterOrigineId != null && ParameterOrigineId != 0)
            {
                queryActionQSE = queryActionQSE.Where(q => q.NonConformite.NonConformiteOrigineId == ParameterOrigineId);
            }
            if (ParameterGraviteId != null && ParameterGraviteId != 0)
            {
                queryActionQSE = queryActionQSE.Where(q => q.NonConformite.NonConformiteGraviteId == ParameterGraviteId);
            }
            if (ParameterDomaineId != null && ParameterDomaineId != 0)
            {
                queryActionQSE = queryActionQSE.Where(q => q.NonConformite.NonConformiteDomaineId == ParameterDomaineId);
            }

            int RecordsFiltered = queryActionQSE.Count();
            int RecordsTotal = _db.ActionQSEs.Count();

            queryActionQSE = queryActionQSE.Skip(ParameterStart).Take(ParameterLength);

            List<ActionQSE> AllActionQSE = queryActionQSE.ToList();

            DataTableViewModel<ActionQSE> DataTableViewModel = new DataTableViewModel<ActionQSE>()
            {
                recordsTotal = RecordsTotal,
                recordsFiltered = RecordsFiltered,
                data = AllActionQSE
            };


            return DataTableViewModel;

        }

    }
}
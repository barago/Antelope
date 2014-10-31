using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.Socle.DataTables
{
    public class DataTableViewModel<T>
    {
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public int sEcho { get;set; }

        public List<T> aaData { get; set; }
    }
}
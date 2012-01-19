using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MibClient2.Web.Tools;

namespace DXAnalytics.Models
{
    public class ReportFilters
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public int PlanId;

        public static ReportFilters GetFromCookie()
        {
            var filters = new ReportFilters();
            var ck = new MibCookie("userData", null);
            filters.StartDate = ck.GetDateTime("start","pt-br");

            filters.EndDate = ck.GetDateTime("finish", "pt-br");
            filters.PlanId = ck.GetInt32("filter");
            return filters;
        }
    }
}
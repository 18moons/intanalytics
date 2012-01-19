using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MibClient2.Cache;
using MibClient2.Database;

namespace DXAnalytics.Models
{
    public partial class SubscriptionPlan
    {
        public static List<SubscriptionPlan> GetAllPlans()
        {
            var returnList = MibCache.GetObject("planList") as List<SubscriptionPlan>;
            if (returnList == null)
            {
                var Sql = "SELECT ID FROM DX_SUBSCRIPTION_PLANS";
                returnList = MibSql.Default.CreateQuery(Sql).GetMibObjectList<SubscriptionPlan>();
                MibCache.Add(returnList, "planList", 500);
            }
            return returnList;
        }
    }
}
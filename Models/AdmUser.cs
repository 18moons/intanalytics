using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MibClient2.Database;
using MibClient2.Crypto;

namespace DXAnalytics.Models
{
    public partial class AdmUser
    {
        public static AdmUser UserLogin(string username, string password)
        {
            var hashGen = new MibHashMD5();
            var hash = "";

            byte[] buffer=hashGen.GenerateHashString(password);

            foreach (byte b in buffer) hash += b.ToString("x2");

            var Sql = "select id from adm_users where LOGIN=? and password=?";
            var SqlBuilder = new MibSqlBuilder(Sql);
            SqlBuilder.AddParameter(username);
            SqlBuilder.AddParameter(hash);

            return MibSql.Default.CreateQuery(SqlBuilder).GetMibObject<AdmUser>();
        }
    }
}
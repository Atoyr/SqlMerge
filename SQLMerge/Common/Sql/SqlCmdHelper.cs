using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.Common.Sql
{
    public static class SqlCmdHelper
    {
        public static string ExecuteQuery(
            string datasource,
            string user,
            string password,
            string query)
            => ExecuteQuery(new SqlCmdConfig() { Datasource = datasource, User = user, Password = password }, query);

        public static string ExecuteQuery(SqlCmdConfig config, string query) => DosCommandHelper.Execute(config.SqlCmdExePath, config.ExecuteQueryArgument(query)).resultStr;
    }
}

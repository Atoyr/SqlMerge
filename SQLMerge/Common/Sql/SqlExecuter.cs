using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.Common.Sql
{
    public class SqlExecuter
    {
        public string DataSource { set; get; } = "(local)";
        public string UserID { set; get; } = string.Empty;
        public string Password { set; get; } = string.Empty;
        public bool IsWindowsAuthentication { set; get; } = true;
        public string InitialCatalog { get; set; } = "master";
        public int ConnectTimeout { get; set; } = 1000;
        public bool AsynchronousProcessing { get; set; } = true;

        public SqlExecuter() { }

        private string GetSqlConnectionString()
        {
            var sb = new SqlConnectionStringBuilder();
            sb.DataSource = this.DataSource;
            if (IsWindowsAuthentication)
            {
                sb.IntegratedSecurity = true;
            }
            else
            {
                sb.UserID = this.UserID;
                sb.Password = this.Password;
            }
            sb.InitialCatalog = this.InitialCatalog;
            sb.ConnectTimeout = this.ConnectTimeout;
            sb.AsynchronousProcessing = this.AsynchronousProcessing;
            return sb.ToString();
        }

        public bool CanConnect()
        {
            using (var con = new SqlConnection(GetSqlConnectionString()))
            {
                con.Open();
                con.Close();
            }
            return true;
        }

        public IEnumerable<IDictionary<string,object>> ExecuteSql(string query)
        {
            var list = new List<IDictionary<string, object>>();
            try
            {
                using (var con = new SqlConnection(GetSqlConnectionString()))
                {
                    con.Open();
                    var com = new SqlCommand(query, con);
                    var reader = com.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        var dict = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {                            
                            dict[reader.GetName(i)] = reader[i];
                        }
                        list.Add(dict);
                    }
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.Common.Sql
{
    public class SqlCmdConfig
    {
        const int PACKET_SIZE = 4096;
        const int LOGIN_TIMEOUT = 8;

        public string SqlCmdExePath { private set; get; } = "sqlcmd";

        private int _packetSize = PACKET_SIZE;
        /// <summary>
        /// クエリ実行時のパケットサイズ
        /// </summary>
        public int PacketSize
        {
            set => _packetSize = (512 <= value && value <= 32767) ? value : PACKET_SIZE;
            get => _packetSize;
        }

        /// <summary>
        /// 管理者専用接続の使用可否
        /// </summary>
        public bool IsDedicatedAdministratorConnection { set; get; } = false;

        private int _loginTimeout = LOGIN_TIMEOUT;
        /// <summary>
        /// サーバ接続時のログインタイムアウト時間
        /// </summary>
        public int LoginTimeout
        {
            set => _loginTimeout = (0 <= value && value <= 65534) ? value : LOGIN_TIMEOUT;
            get => _loginTimeout;
        }

        /// <summary>
        /// Server/InstanceName
        /// </summary>
        public string Datasource { set; get; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { set; get; } = string.Empty;

        /// <summary>
        /// User
        /// </summary>
        public string User { set; get; } = string.Empty;

        /// <summary>
        /// DatabaseName
        /// </summary>
        public string Database { get; set; }

        public SqlCmdConfig() { }

        public SqlCmdConfig(string sqlCmdExePath)
        {
            SqlCmdExePath = sqlCmdExePath;
        }

        /// <summary>
        /// Generate sqlcmd Argument
        /// </summary>
        /// <returns>sqlcmd Arguments</returns>
        public string SqlCmdArgument() => this.ToString();

        /// <summary>
        /// Generate sqlcmd Argument
        /// </summary>
        /// <param name="query">SQL Query</param>
        /// <returns>sqlcmd Arguments</returns>
        public string ExecuteQueryArgument(string query) => string.Join(" ", GenerateArguments().Concat(new[] { $"-Q \"{query}\"" }));

        /// <summary>
        /// Generate sqlcmd Argument
        /// </summary>
        /// <param name="filePath">SQL Query File Path</param>
        /// <returns>sqlcmd Arguments</returns>
        public string ExecuteQueryFileArgument(string filePath) => string.Join(" ", GenerateArguments().Concat(new[] { $"-i \"{filePath}\"" }));

        public override string ToString() => string.Join(" ", GenerateArguments());

        private IEnumerable<string> GenerateArguments()
        {
            yield return $"-S {Datasource}";

            if (!string.IsNullOrEmpty(Database))
            {
                yield return $"-d {Database}";
            }

            if (string.IsNullOrEmpty(User))
            {
                yield return "-E";
            }
            else
            {
                yield return $"-U {User}";
                yield return $"-P {Password}";
            }

            if (PacketSize != PACKET_SIZE)
            {
                yield return $"-a {PacketSize}";
            }
        }
    }
}

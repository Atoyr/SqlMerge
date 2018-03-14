using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLMerge.Common.Sql;
using static System.Console;

namespace SQLMerge.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sqlExecuter = new SqlExecuter();
            sqlExecuter.IsWindowsAuthentication = true;
            sqlExecuter.CanConnect();
            var hoge = sqlExecuter.ExecuteSql("SELECT * FROM sys.object");
            foreach(var row in hoge)
            {
                foreach(var col in row)
                {
                    Write(col.Value);
                }
                WriteLine("");
            }
        }
    }
}

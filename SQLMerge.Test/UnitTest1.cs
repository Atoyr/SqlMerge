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
            sqlExecuter.DataSource = @"localhost";
            sqlExecuter.CanConnect();
            var hoge = sqlExecuter.ExecuteSql("SELECT TOP 10 * FROM sys.objects SELECT TOP 10 * FROM sys.objects ");
            foreach(var row in hoge)
            {
                foreach(var col in row)
                {
                    Write(col.Value);
                }
                WriteLine("");
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            //WriteLine($"{System.Environment.GetEnvironmentVariable("Path")}");
            var conf = new SqlCmdConfig();
            conf.Datasource = @"localhost";
            //WriteLine(Common.DosCommandHelper.Execute(conf.SqlCmdExePath,conf.ExecuteQueryArgument("SELECT TOP 10 * FROM sys.objects SELECT TOP 10 * FROM sys.objects ")).resultStr);
            WriteLine(SqlCmdHelper.ExecuteQuery(conf, "SELECT TOP 10 * FROM sys.objects"));
            //var conf = new SqlCmdConfig();
            //conf.Datasource = @"WFFDB04\WFF_TEST";

            //sqlExecuter.CanConnect();
            //var hoge = sqlExecuter.ExecuteSql("SELECT TOP 10 * FROM sys.objects SELECT TOP 10 * FROM sys.objects ");
            //foreach (var row in hoge)
            //{
            //    foreach (var col in row)
            //    {
            //        Write(col.Value);
            //    }
            //    WriteLine("");
            //}
        }
    }
}

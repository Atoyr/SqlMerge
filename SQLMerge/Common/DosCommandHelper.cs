using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.Common
{
    public static class DosCommandHelper
    {
        public static (int returnCode, string resultStr) Execute(string executablePath, string arguments)
        {
            string resultStr = string.Empty;
            int returnCode = -1;
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = executablePath;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            resultStr = process.StandardOutput.ReadToEnd();
            returnCode = process.ExitCode;
            process.WaitForExit();
            return (returnCode, resultStr);
        }
    }
}

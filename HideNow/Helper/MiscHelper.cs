using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace HideNow.Helper
{
    class MiscHelper
    {
        public static string[] GetProcessesWithPid()
        {
            var result = new List<string>();
            foreach(var process in Process.GetProcesses())
            {
                result.Add(string.Format("PID:{0}|Name: {1}.exe", process.Id, process.ProcessName));
            }
            return result.ToArray();
        }
    }
}

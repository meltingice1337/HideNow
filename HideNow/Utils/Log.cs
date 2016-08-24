using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HideNow.Utils
{
    class Log
    {
        private static string LogPath = "log.txt";

        public static void WriteLog(string log)
        {
            using (StreamWriter sw = File.CreateText(LogPath))
            {
                sw.WriteLine(log);
            }
        }
    }
}

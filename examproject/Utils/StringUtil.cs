using System;
using System.IO;

namespace examproject.Utils
{
    public static class StringUtil
    {
        public static string ReadTestLogToString()
        {
            string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/log_to_add.log");
            string logString = File.ReadAllText(logFile);
            return logString;
        }
    }
}

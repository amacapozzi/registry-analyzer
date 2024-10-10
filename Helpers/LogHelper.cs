using RegistryAnalyzer.Structs;
using System;
using System.Collections.Generic;
using System.IO;

namespace RegistryAnalyzer.Helpers
{
  
    internal class LogHelper
    {
        private static readonly string LogFilePath = "virus.log";

        public static void SaveLog(Log.LogData logData)
        {
            List<string> dataList = new List<string>();

            if (File.Exists(LogFilePath))
            {
                string prevContent = File.ReadAllText(LogFilePath);
                if (!string.IsNullOrWhiteSpace(prevContent))
                {
                    dataList.Add(prevContent);
                }
            }

            string logEntry = CreateLogEntry(logData);
            dataList.Add(logEntry);

            File.WriteAllText(LogFilePath, string.Join(Environment.NewLine, dataList));
        }

        private static string CreateLogEntry(Log.LogData logData)
        {
            return $@"
=== {logData.FileName} ===
{logData.FileResult}
=================================================
";
        }
    }
}
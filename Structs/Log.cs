using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryAnalyzer.Structs
{
    internal class Log
    {
        public class LogData
        {
            public string FileName { get; set; }
            public object FileResult { get; set; }

            public LogData(string fileName, object fileResult)
            {
                FileName = fileName;
                FileResult = fileResult;
            }
        }
    }
}

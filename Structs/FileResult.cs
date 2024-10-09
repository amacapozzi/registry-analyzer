using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryAnalyzer.Structs
{
    internal class FileResult
    {
        public class FileResultData
        {
            public Data data {  get; set; }
        }

        public class Data
        {
            public Object attributes {  get; set; }
        }


    }
}

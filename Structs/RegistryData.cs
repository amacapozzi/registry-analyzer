using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryAnalyzer.Structs
{
    internal class RegistryData
    {
        public class RegistryKeyData
        {
            public string KeyName { get; set; }

            public List<string> KeyFilePath { get; set; }

            public string RegistryFullPath { get; set; }

            public RegistryKeyData(string KeyName, string RegistryFullPath, List<string> KeyFilePath)
            {
                this.KeyName = KeyName;
                this.RegistryFullPath = RegistryFullPath;
                this.KeyFilePath = KeyFilePath;
            }
        }
    }
}

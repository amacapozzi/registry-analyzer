using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace RegistryAnalyzer.Helpers
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

    internal class RegistryHelper
    {
        private static List<string> filePath = new List<string>();

        public static RegistryKeyData isValidRegistryKey(RegistryKey key, string registryPath)
        {
            if (String.IsNullOrEmpty(registryPath))
            {
                return null;
            }

            using (RegistryKey regKey = key.OpenSubKey(registryPath))
            {
                if (regKey == null)
                {
                    Console.WriteLine("Could not open registry key.");
                    return null;
                }

                if (regKey.GetValueNames().Length < 1)
                {
                    Console.WriteLine("{0} Not have subkeynames", regKey.Name);
                    return null;
                }

                foreach (var c in regKey.GetValueNames())
                {
                    if (String.IsNullOrEmpty(c)) continue;
                    Console.WriteLine("Bytes added {0}", c.Length);
                    filePath.Add(c.ToString());
                }
            }

            return new RegistryKeyData(key.ToString(), registryPath, filePath);
        }
    }
}
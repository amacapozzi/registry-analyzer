using Microsoft.Win32;
using RegistryAnalyzer.Structs;
using System;
using System.Collections.Generic;

namespace RegistryAnalyzer.Helpers
{
  

    internal class RegistryHelper
    {
        private static List<string> filePath = new List<string>();

        public static RegistryData.RegistryKeyData isValidRegistryKey(RegistryKey key, string registryPath)
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
                    filePath.Add(c.ToString());
                }
            }

            return new RegistryData.RegistryKeyData(key.ToString(), registryPath, filePath);
        }
    }
}
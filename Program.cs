using Microsoft.Win32;
using RegistryAnalyzer.Helpers;
using System;

namespace RegistryAnalyzer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
      

            try
            {
                RegistryKeyData registryKeyData = RegistryHelper.isValidRegistryKey(Registry.CurrentUser, "Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store");       
                
                foreach (var key in registryKeyData.KeyFilePath)
                {
                    Console.WriteLine(key);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
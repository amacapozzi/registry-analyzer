using Microsoft.Win32;
using RegistryAnalyzer.Helpers;
using RegistryAnalyzer.Structs;
using System;
using System.IO;
using System.Security.Cryptography;

namespace RegistryAnalyzer
{
    internal class Program
    {
        public static SHA256 sHA256 = SHA256Managed.Create();

        public static string GetHash(byte[] fileBytes) => BitConverter.ToString(sHA256.ComputeHash(fileBytes)).Replace("-", "").ToLowerInvariant();

        private static void Main(string[] args)
        {
            try
            {
                RegistryData.RegistryKeyData registryKeyData = RegistryHelper.isValidRegistryKey(Registry.CurrentUser, "Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store");

                foreach (var key in registryKeyData.KeyFilePath)
                {
                    if (!File.Exists(key)) continue;
                    VirusTotalHelper.CheckFile(key).GetAwaiter().GetResult();
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
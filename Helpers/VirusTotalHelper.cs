using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace RegistryAnalyzer.Helpers
{
    internal class VirusTotalHelper
    {
        public static HttpClient httpClient = new HttpClient()
        {
            DefaultRequestHeaders =
            {
                { "x-apikey", $"{Config.VIRUS_TOTAL_APIKEY}" }
            }
        };

        public static async Task CheckFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("{0} No exists", Path.GetFileName(filePath));
                return;
            }

            using (var multipartFormDataContent = new MultipartFormDataContent())
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var streamContent = new StreamContent(fileStream);

                multipartFormDataContent.Add(streamContent, "file", Path.GetFileName(filePath));
                var response = await httpClient.PostAsync($"{Config.BASE_API_URL}/files", multipartFormDataContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    Console.WriteLine($"Failed to send file {response.StatusCode}");
                }
            }
        }
    }
}
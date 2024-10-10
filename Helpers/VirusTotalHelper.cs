using Newtonsoft.Json;
using RegistryAnalyzer.Structs;
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
            using (var multipartFormDataContent = new MultipartFormDataContent())
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var streamContent = new StreamContent(fileStream);

                multipartFormDataContent.Add(streamContent, "file", Path.GetFileName(filePath));
                var response = await httpClient.PostAsync($"{Config.BASE_API_URL}/files", multipartFormDataContent);

                if (response.IsSuccessStatusCode)
                {
                    FileResult.FileResultData fileResult = GetFileReportByHash(Program.GetHash(File.ReadAllBytes(filePath))).GetAwaiter().GetResult();
                    LogHelper.SaveLog(new LogData(Path.GetFileName(filePath), fileResult.data));
                }
                else
                {
                    Console.WriteLine($"Failed to send file {response.StatusCode}");
                }
            }
        }

        private static async Task<FileResult.FileResultData> GetFileReportByHash(string hash)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://www.virustotal.com/api/v3/files/{hash}"))
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                FileResult.FileResultData fileData = JsonConvert.DeserializeObject<FileResult.FileResultData>(response.Content.ReadAsStringAsync().Result);
                return fileData;
            }
        }
    }
}
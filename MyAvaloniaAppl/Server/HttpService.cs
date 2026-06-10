using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AvApplRepo.HttpService
{
    public class GiteaService
    {
        private readonly HttpClient _httpClient;
        private string _baseUrl ;
        //private readonly string _apiToken;
        //private readonly string _urlrepo;

        public GiteaService(string bUrl)
        {
            _baseUrl = bUrl;
            _httpClient = new HttpClient();



            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", apiToken);

        }

        public async Task<string> DownloadHexFile()
        {
            string respAnswer = null;
            try
            {
                //var response = await _httpClient.GetAsync(_baseUrl );
                //response.EnsureSuccessStatusCode();

                respAnswer = await _httpClient.GetStringAsync(_baseUrl );
                

                //respAnswer = "Успех! Ответ: " + respAnswer.ToString();
            }
            catch (Exception ex)
            {
                respAnswer = $"Ошибка: {ex.Message}! "  ;
            }
            return respAnswer;
        }

        public async Task<string> ResponseM(string mess)
        {
            string responseBody = "";

            var resp = new StringContent(mess, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(_baseUrl, resp);

                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                responseBody = $"Ошибка! " + ex.ToString();
            }
             return responseBody;
        }
       
    }

    public class GiteaReleases
    {
        //public string Id { get; set; }
        //public string TagName { get; set; }
        public string Name { get; set; }
        public List<GiteaReleasesAsset> Asset { get; set; }
    }

    public class GiteaReleasesAsset
    {
        public string Name { get; set; }
    }
}

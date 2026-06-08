using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AvApplRepo.HttpService
{
    public class GiteaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _apiToken;
        private readonly string _urlrepo;

        public GiteaService()
        {
            _baseUrl = "http://10.13.79.86:8000";
            _httpClient = new HttpClient();



            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", apiToken);

        }

        public async Task<string> DownloadHexFile()
        {
            string log = null;
            try
            {
                var response = await _httpClient.GetAsync("http://10.13.79.86:8000/get" );
                response.EnsureSuccessStatusCode();

                

                log = "Успех! Ответ: " + response.ToString();
            }
            catch (Exception ex)
            {
                log = $"Ошибка: {ex.Message}! "  ;
            }
            return log;
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

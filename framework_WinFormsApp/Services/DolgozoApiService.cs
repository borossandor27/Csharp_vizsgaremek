using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace framework_WindowsFormsApp.Services
{
    internal class DolgozoApiService
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public DolgozoApiService()
        {
            _apiUrl = ConfigurationManager.AppSettings["RestApiBaseUrl"]
                      ?? "https://retoolapi.dev/t0j7gq/dolgozok";

            _httpClient = new HttpClient();
        }

        // GET ALL
        public async Task<List<Dolgozo>> GetAllAsync()
        {
            var json = await _httpClient.GetStringAsync(_apiUrl);
            return new List<Dolgozo>(Dolgozo.FromJson(json));
        }

        // INSERT
        public async Task<bool> InsertAsync(Dolgozo dolgozo)
        {
            var json = JsonConvert.SerializeObject(dolgozo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_apiUrl, content);
            return response.IsSuccessStatusCode;
        }

        // UPDATE
        public async Task<bool> UpdateAsync(Dolgozo dolgozo)
        {
            var json = JsonConvert.SerializeObject(dolgozo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(
                $"{_apiUrl}/{dolgozo.Id}",
                content
            );

            return response.IsSuccessStatusCode;
        }

        // DELETE
        public async Task<bool> DeleteAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

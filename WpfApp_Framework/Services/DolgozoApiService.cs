using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp_Framework.Models;

namespace WpfApp_Framework.Services
{
    public class DolgozoApiService : IDolgozoApiService
    {
        private readonly string _apiUrl =
            ConfigurationManager.AppSettings["RestApiBaseUrl"];

        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Dolgozo>> GetAllAsync()
        {
            var json = await _httpClient.GetStringAsync(_apiUrl);
            //MessageBox.Show("JSON length = " + json.Length);
            return new List<Dolgozo>(Dolgozo.FromJson(json));
        }

        public async Task<bool> InsertAsync(Dolgozo dolgozo)
        {
            var json = JsonConvert.SerializeObject(dolgozo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_apiUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Dolgozo dolgozo)
        {
            var json = JsonConvert.SerializeObject(dolgozo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_apiUrl}/{dolgozo.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

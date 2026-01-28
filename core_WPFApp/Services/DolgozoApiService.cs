using core_WpfApp.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace core_WpfApp.Services
{
    public class DolgozoApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        // Konstruktor módosítása: HttpClient-t kap dependency injection-ból
        public DolgozoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Ajánlott
                WriteIndented = false
            };
        }

        public async Task<List<Dolgozo>> GetAllAsync()
        {
            try
            {
                var json = await _httpClient.GetStringAsync("");
                return JsonSerializer.Deserialize<List<Dolgozo>>(json, _jsonOptions)
                       ?? new List<Dolgozo>();
            }
            catch (HttpRequestException ex)
            {
                // Logolhatod a hibát
                throw new Exception($"Hiba az adatok lekérésekor: {ex.Message}", ex);
            }
        }

        public async Task<Dolgozo?> GetByIdAsync(long id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{id}");
                if (!response.IsSuccessStatusCode) return null;

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Dolgozo>(json, _jsonOptions);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Hiba a dolgoző lekérésekor (ID: {id}): {ex.Message}", ex);
            }
        }

        public async Task CreateAsync(Dolgozo dolgozo)
        {
            try
            {
                var json = JsonSerializer.Serialize(dolgozo, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("", content);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Hiba a dolgoző létrehozásakor: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(long id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Hiba a dolgoző törlésekor (ID: {id}): {ex.Message}", ex);
            }
        }

        // Opcionális: Update metódus, ha szükséges
        public async Task UpdateAsync(long id, Dolgozo dolgozo)
        {
            try
            {
                var json = JsonSerializer.Serialize(dolgozo, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{id}", content);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Hiba a dolgoző frissítésekor (ID: {id}): {ex.Message}", ex);
            }
        }
    }
}
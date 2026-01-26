using System.Net.Http;
using System.Text;
using System.Text.Json;

public class DolgozoApiService
{
    private static readonly HttpClient _client = new HttpClient();
    private readonly string _baseUrl;

    private readonly JsonSerializerOptions _jsonOptions =
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

    public DolgozoApiService(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public async Task<List<Dolgozo>> GetAllAsync()
    {
        var json = await _client.GetStringAsync(_baseUrl);
        return JsonSerializer.Deserialize<List<Dolgozo>>(json, _jsonOptions)
               ?? new List<Dolgozo>();
    }

    public async Task<Dolgozo?> GetByIdAsync(long id)
    {
        var response = await _client.GetAsync($"{_baseUrl}/{id}");
        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Dolgozo>(json, _jsonOptions);
    }

    public async Task CreateAsync(Dolgozo dolgozo)
    {
        var json = JsonSerializer.Serialize(dolgozo);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(_baseUrl, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(long id)
    {
        var response = await _client.DeleteAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}

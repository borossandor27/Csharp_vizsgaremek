using Core_konzolos.Models;
using System.Net.Http.Json;

namespace Core_konzolos.Services;

public class DolgozoApiService
{
    private readonly HttpClient _client;

    public DolgozoApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Dolgozo>> GetAllAsync()
    {
        return await _client.GetFromJsonAsync<List<Dolgozo>>("")
               ?? new List<Dolgozo>();
    }

    public async Task<Dolgozo?> GetByIdAsync(int id)
    {
        return await _client.GetFromJsonAsync<Dolgozo>($"{id}");
    }

    public async Task<bool> CreateAsync(Dolgozo dolgozo)
    {
        var response = await _client.PostAsJsonAsync("", dolgozo);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Dolgozo dolgozo)
    {
        var response = await _client.PutAsJsonAsync($"{dolgozo.Id}", dolgozo);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _client.DeleteAsync($"{id}");
        return response.IsSuccessStatusCode;
    }
}

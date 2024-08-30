using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

public class UserRepository
{
    private readonly HttpClient _httpClient;

    public UserRepository()
    {
        _httpClient = new HttpClient();
    }

    public async Task<JsonDocument> GetAllUsersAsync()
    {
        var response = await _httpClient.GetAsync("https://fake-json-api.mock.beeceptor.com/users");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var users = JsonDocument.Parse(content);

        return users;
    }

    // public async Task AddUserAsync(dynamic user)
    // {
    //     var userJson = JsonSerializer.Serialize(user);
    //     var content = new StringContent(userJson, System.Text.Encoding.UTF8, "application/json");

    //     var response = await _httpClient.PostAsync("https://fake-json-api.mock.beeceptor.com/users", content);
    //     response.EnsureSuccessStatusCode();
    // }
}
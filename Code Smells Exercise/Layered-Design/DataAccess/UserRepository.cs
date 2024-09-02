using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

public class UserRepository
{
    // TO DO: Use a single HttpClient for better performance and to avoid potential issues
    // private static readonly HttpClient _httpClient = new HttpClient();

    private readonly HttpClient _httpClient;

    public UserRepository()
    {
        _httpClient = new HttpClient();
    }

    public async Task<JsonDocument> GetAllUsersAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("https://fake-json-api.mock.beeceptor.com/users");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var users = JsonDocument.Parse(content);

            return users;
        }
        catch (HttpRequestException ex)
        {
            // TO DO: Handle potential HttpRequestException if the request fails
            Console.WriteLine($"HTTP request error: {ex.Message}");
        }
        catch (JsonException ex)
        {
            // TO DO: Handle potential JsonException if the JSON parsing fails
            Console.WriteLine($"JSON parsing error: {ex.Message}");
        }
    }
}

using System.Text.Json;

namespace Apress.UnitTests.HttpClients;

public class BlogService
{
    private readonly HttpClient _httpClient;

    public BlogService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<string>> GetPostsAsync()
    {
        var response = await _httpClient.GetAsync("https://anthonygiretti/api/articles");
        var json = await response.Content.ReadAsStringAsync();

        if (json == null)
            return new List<string>();
        return JsonSerializer.Deserialize<List<string>>(json);
    }
}

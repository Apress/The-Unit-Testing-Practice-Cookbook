using System.Text.Json;

namespace Apress.UnitTests.HttpClients;

public class TagsService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TagsService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<string>> GetTagsAsync()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync("https://anthonygiretti/api/tags");
        var json = await response.Content.ReadAsStringAsync();

        if (json == null)
            return new List<string>();
        return JsonSerializer.Deserialize<List<string>>(json);
    }
}

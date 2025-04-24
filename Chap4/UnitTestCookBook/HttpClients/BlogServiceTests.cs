using AutoFixture;
using ExpectedObjects;
using RichardSzalay.MockHttp;
using System.Text.Json;
using Xunit;

namespace Apress.UnitTests.HttpClients;

public class BlogServiceTests
{
    [Fact]
    public async Task GetPostsAsync_WhenGetPostsAsyncReturnsBlogtPostsAsString_ShouldReturnAListOfStrings()
    {
        // Arrange
        var fixture = new Fixture();
        var urls = fixture.CreateMany<string>(2);
        var stringfiedUrls = JsonSerializer.Serialize(urls);

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("https://anthonygiretti/api/articles")
                .Respond("application/json", stringfiedUrls);
        var client = new HttpClient(mockHttp);
        var blogService = new BlogService(client);
        var expectedResult = urls.ToList().ToExpectedObject();

        // Act
        var result  = await blogService.GetPostsAsync();

        // Assert
        expectedResult.ShouldEqual(result);
    }
}

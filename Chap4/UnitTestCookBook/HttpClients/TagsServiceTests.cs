using AutoFixture;
using ExpectedObjects;
using NSubstitute;
using RichardSzalay.MockHttp;
using System.Text.Json;
using Xunit;

namespace Apress.UnitTests.HttpClients;

public class TagsServiceTests
{
    [Fact]
    public async Task GetTagsAsync_WhenGetTagsAsyncReturnsTagsAsString_ShouldReturnAListOfStrings()
    {
        // Arrange
        var fixture = new Fixture();
        var tags = fixture.CreateMany<string>(5);
        var stringfiedTags = JsonSerializer.Serialize(tags);

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("https://anthonygiretti/api/tags")
                .Respond("application/json", stringfiedTags);

        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        var client = new HttpClient(mockHttp);
        httpClientFactory.CreateClient().Returns(client);

        var tagsService = new TagsService(httpClientFactory);
        var expectedResult = tags.ToList().ToExpectedObject();

        // Act
        var result = await tagsService.GetTagsAsync();

        // Assert
        expectedResult.ShouldEqual(result);
    }
}

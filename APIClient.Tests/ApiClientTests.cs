using APIClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

[TestClass]
public class ApiClientTests
{
    private Mock<IHttpClientWrapper> _mockHttpClientWrapper;
    private APIHttpClient _apiClient;

    [TestInitialize]
    public void Setup()
    {
        _mockHttpClientWrapper = new Mock<IHttpClientWrapper>();
        _apiClient = new APIHttpClient(_mockHttpClientWrapper.Object);
    }

    [TestMethod]
    public async Task GetAsync_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = new { Id = 1, Name = "Test" };
        var responseString = JsonSerializer.Serialize(expectedResult);
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(responseString)
        };

        _mockHttpClientWrapper.Setup(client => client.GetAsync(It.IsAny<string>()))
            .ReturnsAsync(response);

        // Act
        var result = await _apiClient.GetAsync<object>("https://example.com/api/test");

        // Assert
        Assert.IsNotNull(result);
        var resultJson = JsonSerializer.Serialize(result);
        var expectedJson = JsonSerializer.Serialize(expectedResult);
        Assert.AreEqual(expectedJson, resultJson);
    }

    [TestMethod]
    public async Task GetAsync_ThrowsHttpRequestException()
    {
        // Arrange
        _mockHttpClientWrapper.Setup(client => client.GetAsync(It.IsAny<string>()))
            .ThrowsAsync(new HttpRequestException("Request failed"));

        // Act & Assert
        await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _apiClient.GetAsync<object>("https://example.com/api/test"));
    }

    [TestMethod]
    [ExpectedException(typeof(JsonException), "Serialization error:")]
    public async Task GetAsync_ThrowsJsonException()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("Invalid JSON")
        };

        _mockHttpClientWrapper.Setup(client => client.GetAsync(It.IsAny<string>()))
            .ReturnsAsync(response);

        // Act
        await _apiClient.GetAsync<object>("https://example.com/api/test");
    }

    [TestMethod]
    public async Task SendAsync_ReturnsDeserializedResponse()
    {
        // Arrange
        var url = "https://example.com/api/resource";
        var expectedResult = new { Id = 1, Name = "Test" };
        var responseString = JsonSerializer.Serialize(expectedResult);

        var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(responseString)
        };

        _mockHttpClientWrapper.Setup(client => client.SendAsync(It.IsAny<HttpRequestMessage>()))
            .ReturnsAsync(httpResponseMessage);

        // Act
        var result = await _apiClient.SendAsync<object>(HttpMethod.Get, url);

        // Assert
        Assert.IsNotNull(result);
        var resultJson = JsonSerializer.Serialize(result);
        var expectedJson = JsonSerializer.Serialize(expectedResult);
        Assert.AreEqual(expectedJson, resultJson);
    }

    [TestMethod]
    public async Task SendAsync_ThrowsException_OnHttpError()
    {
        // Arrange
        var url = "https://example.com/api/resource";

        _mockHttpClientWrapper.Setup(client => client.SendAsync(It.IsAny<HttpRequestMessage>()))
            .ThrowsAsync(new HttpRequestException("Request failed"));

        // Act & Assert
        await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _apiClient.SendAsync<object>(HttpMethod.Get, url));
    }
}


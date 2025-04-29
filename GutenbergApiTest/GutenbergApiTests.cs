using GutenbergApi.Models;
using GutenbergApi.Services;
using Moq;
using Moq.Protected;

namespace GutenbergApiTest;

public class GutenbergApiTestsClass
{
    Mock<HttpClient> _httpClientMock;
    Mock<HttpResponseMessage> _httpResponseMessageMock;
    
    [SetUp]
    public void Setup()
    {
        _httpClientMock = new Mock<HttpClient>();
    }

    [Test]
    public void TestApiService()
    {
        var apiService = new ApiService(_httpClientMock.Object);
        Assert.IsNotNull(apiService);
    }
    
    [Test]
    public void TestGetAllBooksWhenSuccess()
    {
        var apiService = new ApiService(_httpClientMock.Object);
        var response = apiService.GetAllBooks();
        
        Assert.IsNotNull(response);
        Assert.IsInstanceOf<Task<ListOfBooks>>(response);
        Assert.IsInstanceOf<ListOfBooks>(response.Result);
    }
    
    [Test]
    public async Task TestGetAllBooksWhenApiError()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync", 
                ItExpr.IsAny<HttpRequestMessage>(), 
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            });
        
        var httpClient = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new Uri(UrlService.BaseUrl)
        };
        
        var apiService = new ApiService(httpClient);
        
        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(async () => 
            await apiService.GetAllBooks());
        
        Assert.That(exception.Message, Contains.Substring("Api error: Status code 500"));
    }
}
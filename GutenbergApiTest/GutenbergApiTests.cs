using System.Net;
using GutenbergApi.Models;
using GutenbergApi.Services;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace GutenbergApiTest
    {
        [TestFixture]
        public class ApiServiceTests
        {
            [Test]
            public async Task GetAllBooks_ReturnsListOfBooks_WhenResponseIsSuccessful()
            {
                // Arrange
                var expectedBooks = new ListOfBooks(1, null, null, new List<Book>
                {
                    new Book(1, "Test Book")
                });
                var json = JsonConvert.SerializeObject(expectedBooks);
    
                var handlerMock = new Mock<HttpMessageHandler>();
                handlerMock.Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(json)
                    });
    
                var httpClient = new HttpClient(handlerMock.Object);
                var apiService = new ApiService(httpClient);
    
                // Act
                var result = await apiService.GetAllBooks();
    
                // Assert
                Assert.IsNotNull(result);
                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result.Results[0].Title, Is.EqualTo("Test Book"));
            }
    
            [Test]
            public void GetAllBooks_ThrowsException_WhenStatusCodeIsNotSuccess()
            {
                // Arrange
                var handlerMock = new Mock<HttpMessageHandler>();
                handlerMock.Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest
                    });
    
                var httpClient = new HttpClient(handlerMock.Object);
                var apiService = new ApiService(httpClient);
    
                // Act & Assert
                var ex = Assert.ThrowsAsync<Exception>(async () => await apiService.GetAllBooks());
                Assert.That(ex.Message, Does.Contain("Status code"));
            }
        }
    }
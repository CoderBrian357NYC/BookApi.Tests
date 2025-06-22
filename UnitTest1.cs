using System.Net;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BookApi.Tests
{
    public class BooksControllerTests : IClassFixture<WebApplicationFactory<BookApi.Program>>
    {
        private readonly WebApplicationFactory<BookApi.Program> _factory;

        public BooksControllerTests(WebApplicationFactory<BookApi.Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetBooks_ReturnsSuccessAndJsonContent()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/books");

            // Assert
            response.EnsureSuccessStatusCode(); // Status code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType?.ToString());
        }
    }
}

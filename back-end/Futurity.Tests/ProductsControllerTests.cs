using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Futurity.Tests.Api.Extensions;
using Futurity.Core.Entities;
using Futurity.Persistence.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using Futurity.Api;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace Futurity.Tests.Api
{
    public class ProductsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public ProductsControllerTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            _httpClient = webApplicationFactory.WithWebHostBuilder(builder =>
            {
                builder.UseTestServer();
                builder.UseEnvironment("Test");
            }).CreateClient();
        }

        [Fact]
        public async Task Add_WithoutCorrectData_ShouldReturn_BadRequest()
        {
            var response = await _httpClient.PostAsJsonAsync("Products/", default(Product));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            response = await _httpClient.PostAsJsonAsync("Products/", new Product
            {
                ProductName = "aefaef",
                ProductDescription = "aefaef",
                UnitPrice = 0,
                UnitsInStock = 0
            });
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Add_WithCorrectData_ShouldReturn_OK()
        {
            var response = await _httpClient.PostAsJsonAsync("Products/", new ProductViewModel
            {
                Name = "Test",
                Description = "Açıklama",
                UnitPrice = 2.45f,
                UnitsInStock = 2434
            });
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task List_WithoutCorrectPaging_ShouldReturn_BadRequest()
        {
            await _httpClient.AssertedGetAsync("Products?page=-1&pageSize=-5", HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task List_WithoutPaging_ShouldReturn_DefaultPagedResult()
        {
            await _httpClient.AssertedGetEntityListFromUri<ProductViewModel>("Products");
        }
    }
}

using Deliveriamo.DTOs.Login;
using Deliveriamo.DTOs.Product;
using DeliveriamoMain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Deliveriamo
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory<DeliveriamoMain.Program>>
    {
        private readonly CustomWebApplicationFactory<DeliveriamoMain.Program> _factory;
        private HttpClient _httpClient;

        public ProductControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true
            });
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            var token = GetToken().Result;
            _httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", token);
        }


        [Fact]
        public async void AddProduct_Returns_Created_Product()
        {
            // arrange
            var request = new AddProductRequestDto()
            {
                Name = "Coca",
                Description = "company",
                PriceUnit = 10,
                CategoryId = 1,
            };
            HttpContent httpContent = SetPostRequest(request);

            //act 
            var response = await _httpClient.PostAsync("/api/Product/AddProduct", httpContent);
            // leggo il content della generica HttpresponseMessage, e la deserializzo in un oggetto
            var deserializedRepsonse = JsonConvert.DeserializeObject<AddProductResponseDto>(await response.Content.ReadAsStringAsync());
            // Assert
            // success è parte della base response. deve essere true, altrimenti vuol dire che abbiamo generato eccezione
            deserializedRepsonse.Success.Should().BeTrue();
            // l'id deve essere valorizzato
            deserializedRepsonse.Id.Should().Be(1);

        }


        [Fact]
        public async void AddMultipleProduct_Returns_Created_Product()
        {
            // arrange
            var request = new AddProductRequestDto()
            {
                Name = "Coca",
                Description = "company",
                PriceUnit = 10,
                CategoryId = 1,
            };
            HttpContent httpContent = SetPostRequest(request);

            //act 
            AddProductResponseDto deserializedRepsonse = await SendRequest(httpContent);
            // Assert
            // success è parte della base response. deve essere true, altrimenti vuol dire che abbiamo generato eccezione
            deserializedRepsonse.Success.Should().BeTrue();
            // l'id deve essere valorizzato
            deserializedRepsonse.Id.Should().Be(1);




            //act 
            AddProductResponseDto deserializedRepsonse2 = await SendRequest(httpContent);
            // Assert
            // success è parte della base response. deve essere true, altrimenti vuol dire che abbiamo generato eccezione
            deserializedRepsonse2.Success.Should().BeTrue();
            // l'id deve essere valorizzato
            deserializedRepsonse2.Id.Should().Be(2);





        }

        private async Task<AddProductResponseDto> SendRequest(HttpContent httpContent)
        {
            var response = await _httpClient.PostAsync("/api/Product/AddProduct", httpContent);
            // leggo il content della generica HttpresponseMessage, e la deserializzo in un oggetto
            var deserializedRepsonse = JsonConvert.DeserializeObject<AddProductResponseDto>(await response.Content.ReadAsStringAsync());
            return deserializedRepsonse;
        }

        private static HttpContent SetPostRequest(object request)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8);
            httpContent.Headers.Remove("Content-Type");
            httpContent.Headers.Add("Content-Type", "application/json");
            return httpContent;
        }


        private async Task<string> GetToken()
        {
            var request = new LoginRequestDto()
            {
                Username = "ciccio",
                Password = "torta"
            };
            HttpContent httpContent = SetPostRequest(request);

            //act 
            var response = await _httpClient.PostAsync("/api/Login/Login", httpContent); //api/[controller]/[action]
            // leggo il content della generica HttpresponseMessage, e la deserializzo in un oggetto
            var deserializedRepsonse = JsonConvert.DeserializeObject<LoginResponseDto>(await response.Content.ReadAsStringAsync());
            // Assert
            return deserializedRepsonse.Token;
        }

    }
}

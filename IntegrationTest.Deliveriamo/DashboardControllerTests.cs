using Deliveriamo.DTOs.Dashboard;
using Deliveriamo.DTOs.Login;
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
    public class DashboardControllerTests : IClassFixture<CustomWebApplicationFactory<DeliveriamoMain.Program>>
    {
        private readonly CustomWebApplicationFactory<DeliveriamoMain.Program> _factory;
        private HttpClient _httpClient;

        public DashboardControllerTests(CustomWebApplicationFactory<Program> factory)
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
        public async Task GetShopKeepers_Returns_Ok_Status_Code()
        {
            var response = await _httpClient.GetAsync("/api/dashboard/GetShopKeepers");
            response.EnsureSuccessStatusCode(); 
            var deserializedResponse = JsonConvert.DeserializeObject<GetShopKeepersResponseDto>(await response.Content.ReadAsStringAsync());
            deserializedResponse.Success.Should().BeTrue();
            deserializedResponse.ShopKeepers.Count.Should().Be(1);
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

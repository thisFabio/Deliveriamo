using Deliveriamo.DTOs.Login;
using DeliveriamoMain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace IntegrationTest.Deliveriamo
   
{
    public class LoginControllerTests : IClassFixture<CustomWebApplicationFactory<DeliveriamoMain.Program>>
    {
        private readonly CustomWebApplicationFactory<DeliveriamoMain.Program> _factory;
        private HttpClient _httpClient;

        public LoginControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient(new WebApplicationFactoryClientOptions{
                AllowAutoRedirect = true
            });
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
        }
        // TODO
        //quando username e pass errati token vuoto

        //quando username vuoto e pass piena non scoppia

        //quando username pieno e pass vuota non scoppia

        //quando username e pass entrambi vuoti non scoppia

        //[Theory]
        //[InlindeData("user","pass",expected)





        [Fact]
        public async void LoginControllerWhenUserExists_Returns_Token ()
        {
            // arrange
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
            Assert.True(response.IsSuccessStatusCode);
            deserializedRepsonse.Token.Should().NotBeNull();
        }

        private static HttpContent SetPostRequest(object request)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8);
            httpContent.Headers.Remove("Content-Type");
            httpContent.Headers.Add("Content-Type", "application/json");
            return httpContent;
        }
    }
}
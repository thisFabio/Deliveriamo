using Deliveriamo.DTOs.Login;
using Deliveriamo.DTOs.Register;
using DeliveriamoMain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Deliveriamo
{
    public class RegisterControllerTest : IClassFixture<CustomWebApplicationFactory<DeliveriamoMain.Program>>
    {
        private readonly CustomWebApplicationFactory<DeliveriamoMain.Program> _factory;
        private HttpClient _httpClient;

        public RegisterControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true
            });
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json");

        }

        [Theory]
        [InlineData("ciccio", "torta", true)]
        [InlineData("", "torta", false)]
        [InlineData("ciccio", "", false)]
        [InlineData(null, "torta", false)]
        [InlineData("ciccio", null, false)]
        [InlineData("antonio", "rossi", false)]

        public async void RegisterController_Returns_Created_User(string username, string password, bool result)
        {
            // arrange
            var request = new LoginRequestDto()
            {
                Username = username,
                Password = password
            };
            HttpContent httpContent = SetPostRequest(request);

            //act 
            var response = await _httpClient.PostAsync("/api/Register/Register", httpContent); //api/[controller]/[action]
            // leggo il content della generica HttpresponseMessage, e la deserializzo in un oggetto
            var deserializedRepsonse = JsonConvert.DeserializeObject<RegisterResponseDto>(await response.Content.ReadAsStringAsync());
            // Assert

            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData("ciccio", "ciccio", true)]
        public async void RegisterController_Returns_error_User_Already_Created(string username, string secondUsername, bool result) 
        {
            // arrange
            var request = new RegisterRequestDto()
            {
                Username = username,
                Password = "prova",
                Firstname = "ciao",
                Lastname = "pippo",
                Gender = 'f',
                Dob = new DateTime(1976,01,01)
            };
            var secondRequest = new RegisterRequestDto()
            {
                Username = secondUsername,
                Password = "prova",
                Firstname = "ciao",
                Lastname = "pippo",
                Gender = 'f',
                Dob = new DateTime(1976, 01, 01)
            };
            HttpContent httpContent = SetPostRequest(request);

            //act 
            var response = await _httpClient.PostAsync("/api/Register/Register", httpContent); //api/[controller]/[action]
            // leggo il content della generica HttpresponseMessage, e la deserializzo in un oggetto
            var deserializedRepsonse = JsonConvert.DeserializeObject<RegisterResponseDto>(await response.Content.ReadAsStringAsync());
           
            
            httpContent = SetPostRequest(secondRequest);
            response = await _httpClient.PostAsync("/api/Register/Register", httpContent); //api/[controller]/[action]
            var deserializedSecondRepsonse = JsonConvert.DeserializeObject<RegisterResponseDto>(await response.Content.ReadAsStringAsync());


            // Assert


            Assert.True(response.IsSuccessStatusCode);
            deserializedRepsonse.Success.Should().Be(false);
            deserializedRepsonse.ErrorMessage.Should().NotBe(null);
        }
        [Theory]
        [InlineData("ciccio", "torta", true)]
        public async void RegisterController_Returns_Empty_User_If_There_Are_No_Valid_Entries(string username, string password, bool result) 
        {
            // arrange
            var request = new LoginRequestDto()
            {
                Username = username,
                Password = password
            };
            HttpContent httpContent = SetPostRequest(request);

            //act 
            var response = await _httpClient.PostAsync("/api/Register/Register", httpContent); //api/[controller]/[action]
            // leggo il content della generica HttpresponseMessage, e la deserializzo in un oggetto
            var deserializedRepsonse = JsonConvert.DeserializeObject<RegisterResponseDto>(await response.Content.ReadAsStringAsync());
            // Assert
            Assert.True(response.IsSuccessStatusCode);
            deserializedRepsonse.Success.Should().Be(false);
            deserializedRepsonse.Id.Should().Be(0);
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

using Deliveriamo.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using MockQueryable.Core;
using MockQueryable.Moq;
using FluentAssertions;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;
using Xunit;
using Deliveriamo.DTOs.Login;

namespace UnitTest.Deliveriamo
{
    public class LoginServiceTests
    {

        /// <summary>
        /// Testing LOGIN() Method
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("", "", false)]
        [InlineData(null, null, false)]
        [InlineData("ciccio", "giovanni", true)]
        [InlineData("ciccio", "ciccio", true)]
        [InlineData("", null, false)]
        [InlineData(null, "", false)]
        // Testing Login() Method
        public async void WhenUserLogin_ReturnAccordingly(string user, string pass, bool expected)
        {
            // arrange
            var fakeContext = new Mock<IRepositoryService>();
            var username = user;
            var password = pass;
            var fakeUser = new User()

            {
                Firstname = "ciccio",
                Lastname = "ciccio",
                Gender = 'M',
                Dob = new DateTime(1994, 11, 10),
                Enabled = true,
                Username = username,
                Password = password,// torta
                Role = new Role() { Id = 1, RoleName = "admin" },
                RoleId = 1,
                Id = 1
            };
            var fakeUsers = new List<User>();
            fakeUsers.Add(fakeUser);

            var _cryptoService = new CryptoService();

            var hash = password;

            if (!String.IsNullOrEmpty(password))
            {
                hash = _cryptoService.CreateMD5(password).ToLower();
            }

            fakeContext.Setup(x => x.CheckLogin(username, hash)).Returns(Task.FromResult(fakeUser));

            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
            {"JwtEncryptionKey", "che buona la pizza con i fagioli sopra"},
            {"SectionName:SomeKey", "SectionValue"},
        //...populate as needed for the test
            }   ;

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var test = fakeContext.Object;
            var _serviceMocked = new LoginService(configuration, fakeContext.Object, _cryptoService);

            // act
            var result = await _serviceMocked.Login(new LoginRequestDto()
            {
                Username = user,
                Password = pass
            });

            // assert
            if (expected)
            {
                result.Token.Should().NotBeNullOrEmpty();

            }
            else
            {
                result.Token.Should().BeNullOrEmpty();
            }

        }

    }
}
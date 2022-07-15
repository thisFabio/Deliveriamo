using Deliveriamo.Entity;
using Deliveriamo.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using MockQueryable.Core;
using MockQueryable.Moq;
using FluentAssertions;

namespace TestDeliveriamo
{
    public class LoginTests
    {
        [Theory]
        [InlineData("","")]
        [InlineData(null,null)]
        [InlineData("",null)]
        [InlineData(null,"")]
        public async void WhenUserLoginWithEmptyValue_ReturnEmptyToken(string user, string pass)
        {
            // arrange
            var fakeContext = new Mock<DeliveriamoContext>();
            var username = "ciccio";
            var password = "57FFEC0A0664048A8D7142D12D9ED6EB";
            var fakeUsers = new List<User>()
            {
                new User()

                {
                    Firstname = "ciccio",
                    Lastname = "ciccio",
                    Gender = 'M',
                    Dob = new DateTime(1994,11,10),
                    Enabled = true,
                    Username = username,
                    Password = password ,// torta
                    RoleId = 1,
                    Id = 1
                }
            };
            
            var mock = fakeUsers.AsQueryable().BuildMockDbSet();
            //mock.Setup( x => x.FirstOrDefaultAsync(x=> x.Username == username && x.Password == password).Result..Returns((object[] ids) =>
            //{

            //    return fakeUsers.FirstOrDefault();
            //});
           
             var test = fakeContext.Object;
            var _cryptoService = new CryptoService();
            var _serviceMocked = new LoginService(new Mock<IConfiguration>().Object, fakeContext.Object, _cryptoService);
            
            // act
            var result = await _serviceMocked.Login(new Deliveriamo.DTOs.Login.LoginRequestDto()
            {
                Username = user,
                Password = pass
            });

            // assert
            result.Token.Should().BeNullOrEmpty();

        }
       
    }
}
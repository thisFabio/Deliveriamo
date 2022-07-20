using Deliveriamo.DTOs.Register;
using Deliveriamo.Services.Implementations;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Deliveriamo
{
    public class RegisterServiceTests 
    {

        [Fact]
        public bool AddUser_Should_Be_Complete()
        {
            // Arrange:
            var _cryptoService = new CryptoService();

            var _repositoryService = new Mock<IRepository>();

            var fakeUser = new User()
            {
                Firstname = "Francesco",
                Lastname = "Arrighini",
                Dob = new DateTime(1986, 3, 5),
                Gender = 'M',
                Username = "francesco.arrighini@GMAIL.com",
                Password = "romagnamia",
                Enabled = true,
                RoleId = 1,
                Role = new Role() { Id = 1, RoleName = "admin" },
                Id = 1
            };
            var fakeRequest = new RegisterRequestDto()
            {
                Firstname = "Francesco",
                Lastname = "Arrighini",
                Dob = new DateTime(1986, 3, 5),
                Gender = 'M',
                Username = "francesco.arrighini@GMAIL.com",
                Password = "romagnamia",

            };
            var fakeResponse = new RegisterResponseDto();
            
            // mock della repository di salvataggio dati su DB
             _repositoryService.Setup(x => x.AddUser(It.IsAny<User>())).Returns(Task.FromResult(fakeUser));
            

            // mock save changes
            _repositoryService.Setup(x=>x.SaveChanges()).Returns(Task.FromResult(fakeResponse));
       
            var _fakeRegisterService = new RegisterService(_cryptoService, _repositoryService.Object);

            // Act:
            // fare test di add user del register service.
            var actual = _fakeRegisterService.AddUser(fakeRequest);

            //Assert:
            if (actual.Id >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Theory]
        [InlineData("", "Teodorio", "1976-04-27", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        [InlineData("Giovanni","Teodorio","",'M',"giovaTEO@protonmail.com", "GattoMatto", false)]
        [InlineData("Giovanni","Teodorio","",'M',"", "GattoMatto", false)]
        [InlineData("Giovanni", "Teodorio", "", null, "giovaTEO@protonmail.com", "GattoMatto", false)]
        [InlineData("Giovanni","Teodorio","1976-04-27",'M',"giovaTEO@protonmail.com", "GattoMatto", true)]
        public void AddUser_Should_Work_Properly(
            string firstname,
            string lastname,
            string dob,
            char gender,
            string username,
            string password,
            bool expected
            )
        {
            // Arrange:
            var actual = false;
            bool result;
            var _cryptoService = new CryptoService();

            var _repositoryService = new Mock<IRepository>();

            var fakeUser = new User()
            {
                Firstname = firstname,
                Lastname = lastname,
                Dob = DateTime.Parse(dob),
                Gender = gender,
                Username = username,
                Password = password,
                Enabled = true,
                RoleId = 1,
                Role = new Role() { Id = 1, RoleName = "admin" },
                Id = 1
            };
            var fakeRequest = new RegisterRequestDto()
            {
                Firstname = firstname,
                Lastname = lastname,
                Dob = DateTime.Parse(dob),
                Gender = gender,
                Username = username,
                Password = password

            };
            var fakeResponse = new RegisterResponseDto();

            // DRIVERS :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            
            // mock della repository di salvataggio dati su DB --> AddUser()
            _repositoryService.Setup(x => x.AddUser(It.IsAny<User>())).Returns(Task.FromResult(fakeUser));


            // mock SaveChanges() METHOD
            _repositoryService.Setup(x => x.SaveChanges()).Returns(Task.FromResult(fakeResponse));

            var _fakeRegisterService = new RegisterService(_cryptoService, _repositoryService.Object);
            
            //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            
            // Act:
            // fare test di add user del register service.
            var testAddUser = _fakeRegisterService.AddUser(fakeRequest);

            //Assert:
            if (testAddUser.Id >= 1)
            {
                actual = true;
                 Assert.Equal(expected, actual);
            }
            else
            {
                
                Assert.Equal(expected, actual);
            }
        }
    }
}

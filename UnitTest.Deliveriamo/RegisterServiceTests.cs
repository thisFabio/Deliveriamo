using Deliveriamo.DTOs;
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

        /// <summary>
        ///     Testing AddUser() Method and all possible entries into CREATE Operation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(1,null, "Teodorio", "1976-04-27", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        [InlineData(1,"Giovanni", null, "1976-04-27", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        [InlineData(1,"Giovanni","Teodorio",null,'M',"giovaTEO@protonmail.com", "GattoMatto", false)]
        [InlineData(1, "Giovanni", "Teodorio", "1976-04-27", null, "giovaTEO@protonmail.com", "GattoMatto", false)]
        [InlineData(1, "Giovanni", "Teodorio", "1976-04-27", 'M', null, "GattoMatto", false)]
        [InlineData(1, "Giovanni", "Teodorio", "1976-04-27", 'M', "giovaTEO@protonmail.com",null , false)]
        //empty string values 
        [InlineData(1, "", "Teodorio", "1976-04-27", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        [InlineData(1, "Giovanni", "", "1976-04-27", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        [InlineData(1, "Giovanni", "Teodorio", "", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        [InlineData(1, "Giovanni", "Teodorio", "1976-04-27", 'M', "", "GattoMatto", false)]
        [InlineData(1, "Giovanni", "Teodorio", "1976-04-27", 'M', "giovaTEO@protonmail.com", "", false)]
        // wrong charachter
        [InlineData(1, "Giovanni", "Teodorio", "1976-04-27",'1' , "giovaTEO@protonmail.com", "GattoMatto", false)]
        //not valid datetime
        [InlineData(1,"Giovanni","Teodorio","1",'M',"giovaTEO@protonmail.com", "GattoMatto", false)]
        // correct insert
        [InlineData(1, "Giovanni", "Teodorio", "1976 - 04 - 27", 'M', "giovaTEO@protonmail.com", "GattoMatto", true)]


        public void AddUser_Should_Work_Properly(
            int id,
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
            
           
            var _cryptoService = new CryptoService();

            var _repositoryService = new Mock<IRepositoryService>();

            DateTime DOB;
            DateTime.TryParse(dob, out DOB);

            var fakeUser = new User()
            {
                Firstname = firstname,
                Lastname = lastname,
                Dob = DOB,
                Gender = gender,
                Username = username,
                Password = password,
                Enabled = true,
                RoleId = 1,
                Role = new Role() { Id = 1, RoleName = "admin" },
                Id = id
            };
            var fakeRequest = new RegisterRequestDto()
            {
                Firstname = firstname,
                Lastname = lastname,
                Dob = DOB,
                Gender = gender,
                Username = username,
                Password = password

            };
            var fakeResponse = new RegisterResponseDto();

            // DRIVERS :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            
            // mock della repository di salvataggio dati su DB --> AddUser()
            _repositoryService.Setup(x => x.AddUser(fakeRequest.ToEntity(""))).Returns(Task.FromResult(fakeRequest.ToEntity("")));


            // mock SaveChanges() METHOD
            _repositoryService.Setup(x => x.SaveChanges()).Returns(Task.CompletedTask);

            var _fakeRegisterService = new RegisterService(_cryptoService, _repositoryService.Object);
            
            //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            
            // Act:
            // fare test di add user del register service.
            var testAddUser = _fakeRegisterService.AddUser(fakeRequest);

            //Assert:
            //Assert.Equal(expected, testAddUser.Id == id);
            if (expected)
            {
                _repositoryService.Verify(x => x.AddUser(It.IsAny<User>()),Times.Once());
                _repositoryService.Verify(x => x.SaveChanges(),Times.Once());

            }
            else
            {
                _repositoryService.Verify(x => x.AddUser(It.IsAny<User>()), Times.Never());
                _repositoryService.Verify(x => x.SaveChanges(), Times.Never());
            }

           

        }

    }
}

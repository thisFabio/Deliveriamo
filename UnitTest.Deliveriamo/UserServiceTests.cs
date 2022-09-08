using Castle.Components.DictionaryAdapter.Xml;
using Deliveriamo.DTOs;
using Deliveriamo.DTOs.Register;
using Deliveriamo.DTOs.User;
using Deliveriamo.Services.Exceptions;
using Deliveriamo.Services.Implementations;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnittestDeliveriamo.Entity;
using Xunit;

namespace UnitTest.Deliveriamo
{
    public class UserServiceTests
    {

        // This test should return always the complete list of users with every kind of etry
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaa")]
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData(null)]
        public async void GetAllUsers_Should_return_valid_entries(string username)
        {
            // Arrange
            
            //creating users object in order to run test
            List<User> usersList = new List<User>()
            {
                new User()
                {
                Firstname = "asdfadf",
                Lastname = "ciccio",
                Gender = 'M',
                Dob = new DateTime(1999, 5, 25),
                Enabled = true,
                Username = "qqq",
                Password = "bbb",// torta
                Role = new Role() { Id = 1, RoleName = "admin" },
                RoleId = 1,
                Id = 1
                },
                                new User()
                {
                Firstname = "aaaaaa",
                Lastname = "sfbtdgnrh",
                Gender = 'M',
                Dob = new DateTime(1988, 1, 17),
                Enabled = true,
                Username = "sdbbg",
                Password = "1234",// torta
                Role = new Role() { Id = 1, RoleName = "admin" },
                RoleId = 3,
                Id = 2
                },
                                new User()
                {
                Firstname = "asdfadf",
                Lastname = "mirimrirg",
                Gender = 'F',
                Dob = new DateTime(1993, 11, 10),
                Enabled = true,
                Username = "rrrr",
                Password = "eeee",// torta
                Role = new Role() { Id = 1, RoleName = "admin" },
                RoleId = 1,
                Id = 3
                }

            };

            // Mocking fake repository in order to run test.
            var mockedRepo = new Mock<IRepositoryService>();
            mockedRepo.Setup(x => x.GetUsers()).Returns(Task.FromResult(usersList));

            // create a mocked service 
            var _service = new UserService(mockedRepo.Object);

            GetAllUsersRequestDto request = new GetAllUsersRequestDto()
            {
                Username = username,
            };

            //Act
            //Calling the method to be Tested
            GetAllUsersResponseDto result = await _service.GetAllUsers(request);

            //Assert
            //Check if the result should not be null
            result.Users.Should().NotBeNull();
            result.Users.Count().Should().BeGreaterThanOrEqualTo(0);
        }

        // This test should return always the complete list of users with every kind of entry
        [Theory]
        //[InlineData(1, "asfggjd", true)]
        //[InlineData(2, "asfggjd", true)]
        //[InlineData(3, "asfggjd", true)]

        [InlineData(0, "asfggjd", false)]
        [InlineData(-11, "sdjgnsfl", false)]
        [InlineData(3341, "adgwrs", false)]
        [InlineData(null,"", false)]
        [InlineData(null, null, false)]
        //[InlineData(1, null, true)]

        public async void GetUserById_Should_return_exception_if_user_not_found(int userId, string username, bool expected)
        {
            // Arrange
            //creating 2 user object in order to run test
            List<User> usersList = new List<User>()
            {
                new User()
                {
                Firstname = "asdfadf",
                Lastname = "ciccio",
                Gender = 'M',
                Dob = new DateTime(1999, 5, 25),
                Enabled = true,
                Username = "qqq",
                Password = "bbb",// torta
                Role = new Role() { Id = 1, RoleName = "admin" },
                RoleId = 1,
                Id = 1
                },
                new User()
                {
                Firstname = "aaaaaa",
                Lastname = "sfbtdgnrh",
                Gender = 'M',
                Dob = new DateTime(1988, 1, 17),
                Enabled = true,
                Username = "sdbbg",
                Password = "1234",// torta
                Role = new Role() { Id = 1, RoleName = "admin" },
                RoleId = 3,
                Id = 2
                },
                new User()
                {
                Firstname = "asdfadf",
                Lastname = "mirimrirg",
                Gender = 'F',
                Dob = new DateTime(1993, 11, 10),
                Enabled = true,
                Username = "rrrr",
                Password = "eeee",// torta
                Role = new Role() { Id = 1, RoleName = "admin" },
                RoleId = 1,
                Id = 3
                }

            };


            // Mocking fake repository in order to run test.
            var mockedRepo = new Mock<IRepositoryService>();
            mockedRepo.Setup(x => x.GetUserById(userId)).Returns(Task.FromResult(usersList.FirstOrDefault(x=> x.Id == userId)));

            // create a mocked service 
            var _service = new UserService(mockedRepo.Object);

            GetUserRequestDto request = new GetUserRequestDto()
            {
                Id = userId,
                Username = username
            };


            Exception exc = new Exception() {};

            //Act
            //Calling the method Tested
            //try
            //{

            //    result = await _service.GetUserById(request);
            //}
            //catch (Exception ex)
            //{
            //    exc = ex;
            //}

            var result = await Assert.ThrowsAsync<Exception>(() => _service.GetUserById(request));
            //Assert

            // verifico che il messaggio salvato nella variabile result e quello indicato nel metodo siano identici
            Assert.True(result.Message == $"User {request.Id} not found");


        }

        // TODO: DELETE USER
        [Theory]
        [InlineData(100)]
        [InlineData(-1)]
        [InlineData(0)]


        public async void DeleteUser_Should_Raise_Exception_if_user_not_found(int userid)
        {
            //Arrange

            var fakeUserList = new List<User>();
            var _repositoryService = new Mock<IRepositoryService>();


            var mockedRole = new Role() { Id = 1, RoleName = "admin" };
            // Creating first fake user
            var mockedUser = new UserBuilder()
                .WithId(33)
                .WithFirstname("pippo")
                .WithLastname("pluto")
                .WithGender('f')
                .WithPassword("bluemoon")
                .WithDob(DateTime.Now)
                .WithRole(mockedRole)
                .WithRoleId(1)
                .WithUsername("marione90")
                .WithShopKeeper(true)
                .WithPhoneNumber("0456789")
                .WithBusinessTypeName("Pizzeria")
                .WithExtendedCompanyName("Sorbillo srl")
                .WithBusinessName("Da Sorbillo")
                .WithVatNumber("123456789")
                .WithCompanyStreetAddress("Corso Italia")
                .WithCompanyCivicNumber("1")
                .WithCompanyCity("Napoli")
                .WithCompanyPostalCode("12345")
                .WithCompanyCountry("Italia")
                .Build();

            
            //// fai finta che... quando chiamo il metodo DeleteUser --> return expected.
            _repositoryService.Setup(x => x.DeleteUser(mockedUser)).Returns(Task.FromResult(mockedUser));
            _repositoryService.Setup(x => x.GetUserById(33)).Returns(Task.FromResult(mockedUser));

            
            // create a mocked service 
            var _service = new UserService(_repositoryService.Object);

            DeleteUserRequestDto userRequest = new()
            {
                Id = userid
            };

            //Act
            Exception exc = new Exception() { };
            var result = await Assert.ThrowsAsync<Exception>(() => _service.DeleteUser(userRequest));

            //Assert

            // verifico che il messaggio salvato nella variabile result e quello indicato nel metodo siano identici
            Assert.True(result.Message == $"User {userRequest.Id} not found");

        }
        [Fact]
        public async void DeleteUser_Should_work()
        {
            //Arrange
            var _repositoryService = new Mock<IRepositoryService>();


            var mockedRole = new Role() { Id = 1, RoleName = "admin" };
            // Creating first fake user
            var mockedUser = new UserBuilder()
                .WithId(33)
                .WithFirstname("pippo")
                .WithLastname("pluto")
                .WithGender('f')
                .WithPassword("bluemoon")
                .WithDob(DateTime.Now)
                .WithRole(mockedRole)
                .WithRoleId(1)
                .WithUsername("marione90")
                .WithShopKeeper(true)
                .WithPhoneNumber("0456789")
                .WithBusinessTypeName("Pizzeria")
                .WithExtendedCompanyName("Sorbillo srl")
                .WithBusinessName("Da Sorbillo")
                .WithVatNumber("123456789")
                .WithCompanyStreetAddress("Corso Italia")
                .WithCompanyCivicNumber("1")
                .WithCompanyCity("Napoli")
                .WithCompanyPostalCode("12345")
                .WithCompanyCountry("Italia")
                .Build();

            _repositoryService.Setup(x => x.DeleteUser(mockedUser)).Returns(Task.FromResult(mockedUser));
            _repositoryService.Setup(x => x.GetUserById(33)).Returns(Task.FromResult(mockedUser));

            var _userService = new UserService(_repositoryService.Object);
            //Act
            var result = await _userService.DeleteUser(new DeleteUserRequestDto() { Id = 33 });
            //Assert
            result.Id.Should().Be(33);
        }

        // TODO : UPDATE USER
        [Fact]
        public async void UpdateUser_Should_Work_Properly()
        {
            //Arrange
            var mockedRole = new Role() { Id = 1, RoleName = "admin" };
            // Creating first fake user
            var mockedUser = new UserBuilder()
                .WithId(33)
                .WithFirstname("pippo")
                .WithLastname("pluto")
                .WithGender('f')
                .WithPassword("bluemoon")
                .WithDob(DateTime.Now)
                .WithRole(mockedRole)
                .WithRoleId(1)
                .WithUsername("marione90")
                .WithShopKeeper(true)
                .WithPhoneNumber("0456789")
                .WithBusinessTypeName("Pizzeria")
                .WithExtendedCompanyName("Sorbillo srl")
                .WithBusinessName("Da Sorbillo")
                .WithVatNumber("123456789")
                .WithCompanyStreetAddress("Corso Italia")
                .WithCompanyCivicNumber("1")
                .WithCompanyCity("Napoli")
                .WithCompanyPostalCode("12345")
                .WithCompanyCountry("Italia")
                .Build();

            var _repositoryService = new Mock<IRepositoryService>();
            _repositoryService.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(Task.FromResult(mockedUser));


            var userService = new UserService(_repositoryService.Object);
            //Act

            var  response = await userService.UpdateUser(new UpdateUserRequestDto() { BusinessName = "Da Marianna" });

            //Assert
            //fluent assertion
            response.BusinessName.Should().Be("Da Marianna");
        }
        [Theory]
        [InlineData(100)]
        [InlineData(-1)]
        [InlineData(0)]
        public async void UpdateUser_Should_Handle_Invalid_Entries(int userId)
        {
            //Arrange
            var mockedRole = new Role() { Id = 1, RoleName = "admin" };
            // Creating first fake user
            var mockedUser = new UserBuilder()
                .WithId(33)
                .WithFirstname("pippo")
                .WithLastname("pluto")
                .WithGender('f')
                .WithPassword("bluemoon")
                .WithDob(DateTime.Now)
                .WithRole(mockedRole)
                .WithRoleId(1)
                .WithUsername("marione90")
                .WithShopKeeper(true)
                .WithPhoneNumber("0456789")
                .WithBusinessTypeName("Pizzeria")
                .WithExtendedCompanyName("Sorbillo srl")
                .WithBusinessName("Da Sorbillo")
                .WithVatNumber("123456789")
                .WithCompanyStreetAddress("Corso Italia")
                .WithCompanyCivicNumber("1")
                .WithCompanyCity("Napoli")
                .WithCompanyPostalCode("12345")
                .WithCompanyCountry("Italia")
                .Build();

            var _repositoryService = new Mock<IRepositoryService>();
            _repositoryService.Setup(x => x.GetUserById(33)).Returns(Task.FromResult(mockedUser));


            var userService = new UserService(_repositoryService.Object);
            //Act
            Exception exc = new Exception() { };
            var result = await Assert.ThrowsAsync<Exception>(() => userService.UpdateUser(new UpdateUserRequestDto() { Id = userId}));

            //Assert
            result.Message.Should().Be($"User {userId} not found");
        }
    }
}

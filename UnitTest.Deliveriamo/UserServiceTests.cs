using Deliveriamo.DTOs;
using Deliveriamo.DTOs.Register;
using Deliveriamo.DTOs.User;
using Deliveriamo.Services.Exceptions;
using Deliveriamo.Services.Implementations;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;
using FluentAssertions;
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

        // This test should return always the complete list of users with every kind of etry
        [Theory]
        [InlineData(1, "asfggjd", true)]
        [InlineData(2, "asfggjd", true)]
        [InlineData(3, "asfggjd", true)]

        [InlineData(0, "asfggjd", false)]
        [InlineData(-11, "sdjgnsfl", false)]
        [InlineData(3341, "adgwrs", false)]
        [InlineData(null,"", false)]
        [InlineData(null, null, false)]
        [InlineData(1, null, true)]

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

            GetUserResponseDto result = new GetUserResponseDto();
            Exception exc = new Exception() {};

            //Act
            //Calling the method Tested
            try
            {

                result = await _service.GetUserById(request);
            }
            catch (Exception ex)
            {
                exc = ex;
            }

            //Assert
            //Check if the error message has been raised. or if it equal to the original error message.

            if (expected)
            {
                result.Users.Should().NotBeNullOrEmpty();
            }
            else
            {
               Assert.Equal(exc.Message, $"User {userId} not found");

            }
            //var actual =  result.Users.Should().NotBeNullOrEmpty();
            //Assert.Equal(actual.ToString(), expected.ToString());

        }

    }
}

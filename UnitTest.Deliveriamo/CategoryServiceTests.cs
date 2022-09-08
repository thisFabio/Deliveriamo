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
    public class CategoryServiceTests
    {

        // TODO: FIX GET ALL CATEGORIES

        // This test should return always the complete list of users with every kind of etry
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaa")]
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData(null)]
        public async void GetAllCategories_Should_return_valid_entries(string username)
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


        // TODO: ADD CATEGORY

        // TODO: DELETE CATEGORY

        // TODO : UPDATE CATEGORY

    }
}

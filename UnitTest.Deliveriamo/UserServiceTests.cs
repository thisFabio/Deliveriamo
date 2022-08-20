using Deliveriamo.DTOs;
using Deliveriamo.DTOs.Register;
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
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(null)]
        public async void GetAllUsers_Should_return_valid_entries(int userId)
        {
            // Arrange
            //Create inmemory db, creating 2 user object in order to run test

            //Act
            //Calling the method Tested

            //Assert
            //Check if the result should not be null
            
        }

        // This test should return always the complete list of users with every kind of etry
        [Theory]
        [InlineData(0)]
        [InlineData(-11)]
        [InlineData(3341)]
        [InlineData(null)]
        public async void GetUserById_Should_return_exception_if_user_not_found(int userId)
        {
            // Arrange
            //Create inmemory db, creating 2 user object in order to run test

            //Act
            //Calling the method Tested

            //Assert
            //Check if the error message has been raised. or if it equal to the original error message.

        }

    }
}

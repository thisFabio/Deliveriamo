using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliveriamo.Services.Implementations;
using FluentAssertions.Common;
using UnittestDeliveriamo.Entity;
using Xunit;
using Deliveriamo.DTOs;
using Deliveriamo.DTOs.Register;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;

namespace UnitTest.Deliveriamo
{
    public class CryptoServiceTests
    {
        [Theory]
        [InlineData("provola", "3838b44ad2c4d4110e080ecf42a046ec", true)]
        [InlineData("mare", "34c119dc749297336f7a1c8b54290123", true)]
        [InlineData("tortellini", "cda2749bd2d29657f051afcf6dd6da53", true)]
        [InlineData("tortellini", "cda2749bd2d29657f051afcf6ddda53", false)]


        public void CreateMD5_should_Return_True(string input, string output, bool expected)
        {
            //Arrange
            var _cryptoService = new CryptoService();

            //Act
            string actual = _cryptoService.CreateMD5(input);

            //Assert
            Assert.Equal(actual.Equals(output).ToString(), expected.ToString());
        }



    }
}

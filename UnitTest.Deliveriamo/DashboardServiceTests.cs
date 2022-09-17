using Deliveriamo.DTOs.Dashboard;
using Deliveriamo.Services.Implementations;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Deliveriamo
{
    public class DashboardServiceTests
    {
        // ritorni dei dati
        [Fact]
        public async void GetShopKeepers_Should_Returns_Data()
        {
            // Arrange
            var listOfShopKeepers = new List<User>();
            listOfShopKeepers.Add(new User() { Id = 1, BusinessName = "ShopKeeper1", CompanyStreetAddress = "Address1" });
            listOfShopKeepers.Add(new User() { Id = 2, BusinessName = "ShopKeeper2", CompanyStreetAddress = "Address2" });
            listOfShopKeepers.Add(new User() { Id = 3, BusinessName = "ShopKeeper3", CompanyStreetAddress = "Address3" });
            

            var mockedRepo = new Mock<IRepositoryService>();
            mockedRepo.Setup(x => x.GetAllShopKeepers()).Returns(Task.FromResult(listOfShopKeepers));
            var request = new GetShopKeepersRequestDto() { ShopKeeperName = "ShopKeeper" };
            var service = new DashboardService(mockedRepo.Object);
            
            // Act
            var result = await service.GetShopKeepers(request);
            
            
            // Assert
            Assert.NotNull(result);
            result.Success.Should().BeTrue();
            result.ShopKeepers.Count.Should().BeGreaterThan(0);
        }
    }
}

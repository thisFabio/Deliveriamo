using Deliveriamo.DTOs.Product;
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
    public class ProductServiceTests
    {
        //[Fact]
    //    public async void AddProduct_Should_return_valid_Product()
    //    {
    //        //Arrange
    //        var mockedProduct = new Product()
    //        { 
    //            Name = "Product 1",
    //            Description = "Product 1 Description",
    //            PriceUnit = 10,
    //            CategoryId = 1
    //        };

    //        var mockedRepo = new Mock<IRepositoryService>();
    //        mockedRepo.Setup(x => x.AddProduct(mockedProduct)).Returns(Task.FromResult(mockedProduct));
    //        mockedRepo.Setup(x => x.SaveChanges()).Returns(Task.CompletedTask);

    //        var productService = new ProductService(mockedRepo.Object);
            
    //        // act 
    //        var res = await productService.AddProduct(new AddProductRequestDto()
    //        {
    //            Name = mockedProduct.Name,
    //            CategoryId = mockedProduct.CategoryId,
    //            Description = mockedProduct.Description,
    //            PriceUnit = mockedProduct.PriceUnit
    //        });


    //        // assert
    //        res.Success.Should().BeTrue();
    //        res.Id.Should().Be(0);


    //    //}
    }
}

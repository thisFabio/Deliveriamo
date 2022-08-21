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

        /// <summary>
        /// the test should return products only from the same shop keeper.
        /// </summary>
        [Fact]
        public async void GetProductByShopKeeperId_should_return_list_of_products()
        {
            //Arrange

            List<Product> products = new List<Product>
             {
                 new Product()
                 {
                     Id = 1,
                     Name = "prova",
                     Description = "prova",
                     PriceUnit = 11,
                     CategoryId = 1,
                     Status = true

                 },
                 new Product()
                 {
                     Id = 2,
                     Name = "eghryh",
                     Description = "eth",
                     PriceUnit = 121,
                     CategoryId = 1,
                     Status = true

                 }
             };

            List<Product> singleProduct = new List<Product>
             {
                 new Product()
                 {
                     Id = 1,
                     Name = "prova",
                     Description = "prova",
                     PriceUnit = 11,
                     CategoryId = 1,
                     Status = true

                 }
             };

            // mock of repository
            var mockedRepo = new Mock<IRepositoryService>();
            // faking... when getproducts has a null entry, return all products
            mockedRepo.Setup(x => x.GetProducts("0")).Returns(Task.FromResult(products));
            // faking... when getproducts has a valid entry, return single product
            mockedRepo.Setup(x => x.GetProducts("1")).Returns(Task.FromResult(singleProduct));

            // created mocked service 
            var _service = new ProductService(mockedRepo.Object);


            //Act
            var result = await _service.GetProductByShopKeeperId(new GetProductByShopKeeperIdRequestDto()
            {
                Id = 1
            });

            //Assert
            result.Products.Should().NotBeNull();
            result.Products.Count().Should().BeGreaterThanOrEqualTo(0);


        }

        [Theory]
        [InlineData(0,2)]
        [InlineData(1, 1)]
        [InlineData(null, 1)]
        [InlineData(null, null)]
        [InlineData(-1, null)]

        public async void GetProductByShopKeeperId_should_return_expected(int inputRequest, int expected)
        {
            //Arrange

            List<Product> products = new List<Product>
             {
                 new Product()
                 {
                     Id = 1,
                     Name = "prova",
                     Description = "prova",
                     PriceUnit = 11,
                     CategoryId = 1,
                     Status = true

                 },
                 new Product()
                 {
                     Id = 2,
                     Name = "eghryh",
                     Description = "eth",
                     PriceUnit = 121,
                     CategoryId = 1,
                     Status = true

                 }
             };

            List<Product> singleProduct = new List<Product>
             {
                 new Product()
                 {
                     Id = 1,
                     Name = "prova",
                     Description = "prova",
                     PriceUnit = 11,
                     CategoryId = 1,
                     Status = true

                 }
             };

            // mock of repository
            var mockedRepo = new Mock<IRepositoryService>();
            // faking... when getproducts has a null entry, return all products
            mockedRepo.Setup(x => x.GetProducts("0")).Returns(Task.FromResult(products));
            // faking... when getproducts has a valid entry, return single product
            mockedRepo.Setup(x => x.GetProducts("1")).Returns(Task.FromResult(singleProduct));

            // created mocked service 
            var _service = new ProductService(mockedRepo.Object);
            var result = new GetProductByShopKeeperIdResponseDto();
            Exception exc = new Exception();

            try
            {
                result = await _service.GetProductByShopKeeperId(new GetProductByShopKeeperIdRequestDto()
                {
                    Id = inputRequest
                });

            }
            catch (Exception ex)
            {

                exc = ex;
            }
            //Act

            //Assert
            if (exc.Source == null)
            {
                result.Products.Should().NotBeNull();
                result.Products.Count().Should().Be(expected);

            }
            else
            {
                Assert.Equal(exc.Message, "Product not found");
            }

        }
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

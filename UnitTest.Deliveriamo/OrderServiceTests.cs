using Deliveriamo.DTOs.Enums;
using Deliveriamo.DTOs.Order;
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
    public class OrderServiceTests
    {

        /// <summary>
        /// the test should return valid order entry.
        /// </summary>
        [Fact]
        public async void AddOrder_Should_Return_ValidOrderEntry()
        {
            //Arrange
            string userId = "1";
            var request = new AddOrderRequestDto()
            {
                PaymentMethod = "card",
                OrderDescription = "prova prova",
                OrderTotalAmount = 1221.5m,
                ProductIds = new List<int>() { 1, 3, 4, 6 },
                ShopKeeperId = 1

            };

            var order = new Order()
            {
                Id = 1,
                UserId = Convert.ToInt32(userId),
                PaymentMethod = request.PaymentMethod,
                OrderDescription = request.OrderDescription,
                OrderTotalAmount = request.OrderTotalAmount,
                OrderCreationDateTime = DateTime.Now,
                LastUpdateDateTime = DateTime.Now,
                DeliveryTime = 45,
                ShopKeeperId = request.ShopKeeperId
            };

            var result = new AddOrderResponseDto();



            // mock of repository
            var mockedRepo = new Mock<IRepositoryService>();
            // faking add order response by repositorry method.
            mockedRepo.Setup(x => x.AddOrder(order, userId)).Returns(Task.FromResult(order));       
     

            // create mocked service 
            var _service = new OrderService(mockedRepo.Object);


            //Act
            result = await _service.AddOrder(request,userId);

            //Assert
            result.Id.Should().Be(0);



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

        //GET ALL PRODUCT TEST
        [Fact]
        public async void GetAllProducts_should_return_all_products()
        {
            //Arrange
            // create a list of products to popolate fake db
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

                 },
                 new Product()
                 {
                     Id = 3,
                     Name = "aaaaa",
                     Description = "aaaaa",
                     PriceUnit = 3,
                     CategoryId = 1,
                     Status = true

                 }
             };

            // mock of repository
            var mockedRepo = new Mock<IRepositoryService>();
            // faking... when getproducts, return all products
            mockedRepo.Setup(x => x.GetAllProducts()).Returns(Task.FromResult(products));
            
            // create mocked service 
            var _service = new ProductService(mockedRepo.Object);

            //Act
            var result = await _service.GetAllProducts(new GetAllProductsRequestDto() { Id = 0});

            //Assert
            result.Products.Count().Should().Be(3);
        }

        // GET PRODUCT BY ID TEST
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void GetProdctById_should_Return_proper_product(int id)
        {
            //Arrange
            // create a list of products to popolate fake db
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

                 },
                 new Product()
                 {
                     Id = 3,
                     Name = "aaaaa",
                     Description = "aaaaa",
                     PriceUnit = 3,
                     CategoryId = 1,
                     Status = true

                 }
             };

            // mock of repository
            var mockedRepo = new Mock<IRepositoryService>();
            // faking... when getproducts, return all products
            mockedRepo.Setup(x => x.GetProductById(id)).Returns(Task.FromResult(products.Find(x=>x.Id == id)));
            // create mocked service 
            var _service = new ProductService(mockedRepo.Object);
            //Act
            var result = await _service.GetProductById(new GetProductByIdRequestDto() { Id = id });
            
            // Assert
            result.Product.Id.Should().Be(id); 
        }

        // GET PRODUCT BY ID TEST
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]

        public async void GetProdctById_should_handle_invalid_entries(int id)
        {
            //Arrange
            // create a list of products to popolate fake db
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

                 },
                 new Product()
                 {
                     Id = 3,
                     Name = "aaaaa",
                     Description = "aaaaa",
                     PriceUnit = 3,
                     CategoryId = 1,
                     Status = true

                 }
             };

            // mock of repository
            var mockedRepo = new Mock<IRepositoryService>();
            // faking... when getproducts, return all products
            mockedRepo.Setup(x => x.GetProductById(id)).Returns(Task.FromResult(products.Find(x => x.Id == id)));
            // create mocked service 
            var _service = new ProductService(mockedRepo.Object);
            //Act
            var result = await Assert.ThrowsAsync<Exception>(() => _service.GetProductById(new GetProductByIdRequestDto() { Id = id }));

            // Assert
            result.Message.Should().Be($"Product {id} not found");
        }
        // ADD PRODUCT TEST
        [Fact]
        public async void AddProduct_should_add_a_new_product()
        {
            //Arrange
            AddProductRequestDto productRequest = new()
            {
                Name = "aaaaa",
                Description = "aaaaa",
                PriceUnit = 3,
                CategoryId = 1,
                Barcode = "123455667",
                UrlImage = "www.tipo.it",
                Status = true
            };

            var mockedProduct = new Product()
            {
                Id = 1,
                Name = productRequest.Name,
                Description = productRequest.Description,
                PriceUnit = productRequest.PriceUnit,
                CategoryId = productRequest.CategoryId,
                Status = productRequest.Status

            };



            string mockedUserId = "1";

            // mock of repository
            var mockedRepo = new Mock<IRepositoryService>();
            // faking... when getproducts, return all products
            mockedRepo.Setup(x => x.AddProduct(mockedProduct,mockedUserId)).Returns(Task.FromResult(mockedProduct));
            // create mocked service 
            var _service = new ProductService(mockedRepo.Object);

            //Act
            var result = await _service.AddProduct(productRequest, mockedUserId);
            //Assert
            result.ErrorMessage.Should().BeNullOrEmpty();
            result.Id.Should().Be(0);

        }

        [Theory]
        [InlineData("aaaaaaaaaaaaaaa", -11,1,true)]
        [InlineData("", 30, 1,true)]
        [InlineData("aaaaaaaaaaaaaaa", -1,2, false)]
        [InlineData("aaaaaaaaaaaaaaa", 1, -3, true)]

        public async void AddProduct_should_handle_invalid_entries(string name, int priceUnit, int categoryId,  bool status)
        {
            //Arrange
            AddProductRequestDto productRequest = new()
            {
                Name = name,
                Description = "aaaaa",
                PriceUnit = priceUnit,
                CategoryId = categoryId,
                Barcode = "123455667",
                UrlImage = "www.tipo.it",
                Status = status
            };

            var mockedProduct = new Product()
            {
                Id = 1,
                Name = productRequest.Name,
                Description = productRequest.Description,
                PriceUnit = productRequest.PriceUnit,
                CategoryId = productRequest.CategoryId,
                Status = productRequest.Status

            };



            string mockedUserId = "1";

            // mock of repository
            var mockedRepo = new Mock<IRepositoryService>();
            // faking... when getproducts, return all products
            //mockedRepo.Setup(x => x.AddProduct(mockedProduct, mockedUserId)).Returns(Task.FromResult(null));
            // create mocked service 
            var _service = new ProductService(mockedRepo.Object);

            //Act
            var result = await Assert.ThrowsAsync<Exception>(() => _service.AddProduct(productRequest, mockedUserId));
            //Assert
            result.Message.Should().Be("Impossible to Add this product, invalid data entry");
            

        }

        // TODO: UPDATE PRODUCT TEST

        // TODO: DELETE PRODUCT TEST

    }
}

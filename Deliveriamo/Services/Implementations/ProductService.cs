    using Deliveriamo.DTOs.Product;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository.Entity;
using Deliveriamo.Services.Exceptions;
using DeliveriamoRepository;
using Microsoft.EntityFrameworkCore;


namespace Deliveriamo.Services.Implementations
{
    public class ProductService : IProductService
    {

        private readonly IRepositoryService _repository;



        public ProductService(IRepositoryService repository)
        {
            _repository = repository;
     
        }


        public async Task<AddProductResponseDto> AddProduct(AddProductRequestDto request, string userId)
        {
            var response = new AddProductResponseDto();

            if (request.PriceUnit < 0 || request.CategoryId < 0 || String.IsNullOrEmpty(request.Name) || String.IsNullOrEmpty(request.Description) || request.Status == null || String.IsNullOrEmpty(userId))
            {
                throw new Exception($"Impossible to Add this product, invalid data entry"); 
            }

            Product product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                PriceUnit = request.PriceUnit,
                CategoryId = request.CategoryId,
                Barcode = request.Barcode,
                UrlImage = request.UrlImage,
                Status = request.Status,
                CreationTime = DateTime.Now
                            
            };
            if (product != null)
            {

                try
                {
                    await _repository.AddProduct(product, userId);
                    await _repository.SaveChanges();

                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }


            response.Id = product.Id;
            return response;
        }

        public async Task<DeleteProductResponseDto> DeleteProduct(DeleteProductRequestDto request)
        {
            var response = new DeleteProductResponseDto();

            var product = await _repository.GetProductById(request.Id);
            
            if (product == null)
            {
                throw new Exception($"Product with id {request.Id} doesn't exist");
            }

            await _repository.DeleteProduct(product);
            await _repository.SaveChanges();
            response.Id = product.Id;


            return response;
        }

        public async Task<GetAllProductsResponseDto> GetAllProducts(GetAllProductsRequestDto request)
        {
            var response = new GetAllProductsResponseDto();

            var dbProductList = await _repository.GetAllProducts();
            await _repository.SaveChanges();
            // converting list of productso to ProductDto
            response.Products = dbProductList.Select(x => new ProductDto(
            
                     x.Id,
                     x.Name,
                     x.PriceUnit,
                     x.Description,
                     x.CategoryId,
                     x.Barcode,
                     x.UrlImage,
                     x.Status,
                     x.CreationTime,
                     x.LastUpdate
            
            )).ToList();
            return response;
        }

        public async Task<GetProductByIdResponseDto> GetProductById(GetProductByIdRequestDto request)
        {

            var response = new GetProductByIdResponseDto();
            var product = await _repository.GetProductById(request.Id);
            if (product == null)
            {
                throw new Exception($"Product {request.Id} not found");
            }

            response.Product = new ProductDto(

                product.Id,
                product.Name,
               product.PriceUnit,
                product.Description,
                product.CategoryId,
                product.Barcode,
                product.UrlImage,
                product.Status,
                product.CreationTime,
                product.LastUpdate);

            return response;
        }

        public async Task<GetProductByShopKeeperIdResponseDto> GetProductByShopKeeperId(GetProductByShopKeeperIdRequestDto request)
        {
            var response = new GetProductByShopKeeperIdResponseDto();
            if (request.Id <= 0 )
            {
                throw new Exception("Product not found");
            }
           var dbProductList = await _repository.GetProducts(request.Id.ToString());

            if (dbProductList.Count() == 0)
            {
                throw new Exception("Product not found");
            }

            // converting list of productso to ProductDto
            response.Products = dbProductList.Select(x => new ProductDto(
                     x.Id,
                     x.Name,
                     x.PriceUnit,
                     x.Description,
                     x.CategoryId,
                     x.Barcode,
                     x.UrlImage,
                     x.Status,
                     x.CreationTime,
                     x.LastUpdate

                     )).ToList();

            return response;
        }

        public async Task<UpdateProductResponseDto> UpdateProduct(UpdateProductRequestDto request)
        {
            var response = new UpdateProductResponseDto();
                
            Product product = await _repository.GetProductById(request.Id);

            if (product == null)
            {
                throw new Exception($"Product with id {request.Id} doesn't exist");
            }

            // filling product with request input
            product.Id = request.Id;
            product.Name = request.Name;
            product.Status = request.Status;
            product.PriceUnit = request.PriceUnit;
            product.Description = request.Description;
            product.CategoryId = request.CategoryId;
            product.Barcode = request.Barcode;
            product.UrlImage = request.UrlImage;
            product.LastUpdate = DateTime.Now;

            //Updating DB
            await _repository.UpdateProduct(product);
            await _repository.SaveChanges();

            // filling data into response
            response.Name = product.Name;
            response.Status = product.Status;
            response.PriceUnit = product.PriceUnit;
            response.Description = product.Description;
            response.CategoryId = product.CategoryId;
            response.Barcode = product.Barcode;
            response.UrlImage = product.UrlImage;
            response.LastUpdate = product.LastUpdate;

            return response;

        }
    }
}

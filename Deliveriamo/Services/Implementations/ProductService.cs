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
        private readonly DeliveriamoContext _context;


        public ProductService(IRepositoryService repository, DeliveriamoContext context)
        {
            _repository = repository;
            _context = context;
        }


        public async Task<AddProductResponseDto> AddProduct(AddProductRequestDto request)
        {
            var response = new AddProductResponseDto();

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
                    await _repository.AddProduct(product);
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

            var product = _context.Product.FirstOrDefault(x=> x.Id == request.Id);
            await _repository.DeleteProduct(product);
            await _repository.SaveChanges();
            response.Id = product.Id;


            return response;
        }

        public async Task<GetProductByShopKeeperResponseDto> GetProductByShopKeeper(GetProductByShopKeeperRequestDto request)
        {
            var response = new GetProductByShopKeeperResponseDto();
                    
            return response;
        }

        public async Task<UpdateProductResponseDto> UpdateProduct(UpdateProductRequestDto request)
        {
            var response = new UpdateProductResponseDto();
                
            Product product = _context.Product.FirstOrDefault(x=> x.Id == request.Id);

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

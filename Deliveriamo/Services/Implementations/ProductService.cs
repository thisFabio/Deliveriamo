using Deliveriamo.DTOs.Product;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository.Entity;
using Microsoft.EntityFrameworkCore;
using DeliveriamoRepository;

namespace Deliveriamo.Services.Implementations
{
    public class ProductService : IProductService
    {

        private readonly ICryptoService _CryptoService;
        private readonly IRepositoryService _repository;

        public async Task<AddProductResponseDto> AddProduct(AddProductRequestDto request)
        {
            var response = new AddProductResponseDto();

            Product product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                PriceUnit = request.PriceUnit,
                Category = new Category()
                {
                    Id = request.CategoryId,
                    Name = request.Name
                }
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

                  }
            response.Id = product.Id;
            return response;
        }

    }
}

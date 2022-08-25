using Deliveriamo.DTOs.Product;

namespace Deliveriamo.Services.Interfaces
{
    public interface IProductService
    {
        Task<AddProductResponseDto> AddProduct(AddProductRequestDto request, string userId);
        Task<DeleteProductResponseDto> DeleteProduct(DeleteProductRequestDto request);
        Task<UpdateProductResponseDto> UpdateProduct(UpdateProductRequestDto request);

        Task<GetProductByShopKeeperIdResponseDto> GetProductByShopKeeperId (GetProductByShopKeeperIdRequestDto request);

        Task<GetProductByIdResponseDto> GetProductById(GetProductByIdRequestDto request);


        Task<GetAllProductsResponseDto> GetAllProducts(GetAllProductsRequestDto request);


    }
}

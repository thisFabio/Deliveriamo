﻿using Deliveriamo.DTOs.Product;

namespace Deliveriamo.Services.Interfaces
{
    public interface IProductService
    {
        Task<AddProductResponseDto> AddProduct(AddProductRequestDto request);
        Task<DeleteProductResponseDto> DeleteProduct(DeleteProductRequestDto request);
        Task<UpdateProductResponseDto> UpdateProduct(UpdateProductRequestDto request);

 

    }
}
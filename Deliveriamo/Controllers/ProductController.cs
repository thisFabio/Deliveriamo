using Deliveriamo.DTOs.Dashboard;
using Deliveriamo.DTOs.Product;
using Deliveriamo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetProductByShopKeeperIdResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> GetProductByShopKeeperId([FromQuery] GetProductByShopKeeperIdRequestDto request)
        {
            GetProductByShopKeeperIdResponseDto result = new();
            try
            {
                result = await _productService.GetProductByShopKeeperId(request);

            }
            catch (Exception ex)
            {

                result.SetExeption(ex.Message);
            }
            return new ObjectResult(result);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetProductByIdResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> GetProductById([FromQuery] GetProductByIdRequestDto request)
        {
            GetProductByIdResponseDto result = new();
            try
            {
                result = await _productService.GetProductById(request);

            }
            catch (Exception ex)
            {

                result.SetExeption(ex.Message);
            }
            return new ObjectResult(result);
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetAllProductsResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsRequestDto request)
        {
            var result = await _productService.GetAllProducts(request);
            return new ObjectResult(result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AddProductResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> AddProduct([FromBody] AddProductRequestDto request)
        {
            var userId = User.Claims.First(x => x.Type == "userid").Value;
            var result = await _productService.AddProduct(request, userId);
            return new ObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateProductResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequestDto request)
        {
            var result = await _productService.UpdateProduct(request);
            return new ObjectResult(result);
        }

        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(DeleteProductResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductRequestDto request)
        {
            var result = await _productService.DeleteProduct(request);
            return new ObjectResult(result);
        }

    }
}

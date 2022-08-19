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
        public async Task<IActionResult> GetProductByShopKeeperId([FromQuery] GetProductByShopKeeperIdRequestDto request)
        {
            var result = await _productService.GetProductByShopKeeperId(request);
            return new ObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequestDto request)
        {
            var userId = User.Claims.First(x => x.Type == "userid").Value;
            var result = await _productService.AddProduct(request, userId);
            return new ObjectResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequestDto request)
        {
            var result = await _productService.UpdateProduct(request);
            return new ObjectResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductRequestDto request)
        {
            var result = await _productService.DeleteProduct(request);
            return new ObjectResult(result);
        }

    }
}

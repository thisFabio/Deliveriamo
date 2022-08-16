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

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequestDto request)
        {
            var result = await _productService.AddProduct(request);
            return new ObjectResult(result);
        }
    }
}

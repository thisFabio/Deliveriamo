using Deliveriamo.DTOs.Category;
using Deliveriamo.DTOs.Dashboard;
using Deliveriamo.DTOs.Login;
using Deliveriamo.DTOs.Product;
using Deliveriamo.Services.Implementations;
using Deliveriamo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetAllCategoryResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoryRequestDto request)
        {
            var result = await _service.GetAllCategories(request);
            return new ObjectResult(result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AddCategoryResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequestDto request)
        {
            var result = await _service.AddCategory(request);
            return new ObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateCategoryResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequestDto request)
        {
            var result = await _service.UpdateCategory(request);
            return new ObjectResult(result);
        }

        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(DeleteCategoryResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategoryRequestDto request)
        {

            var response = new DeleteCategoryResponseDto();

            try
            {
                await _service.DeleteCategory(request);
            }
            catch (Exception ex)
            {
                response.SetExeption(ex.Message);
               
            }
            return new ObjectResult(response);
        }




    }
}

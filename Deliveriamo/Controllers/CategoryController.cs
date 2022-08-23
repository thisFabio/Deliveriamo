using Deliveriamo.DTOs.Category;
using Deliveriamo.DTOs.Dashboard;
using Deliveriamo.DTOs.Login;
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

        //TODO aggiornare questo metodo affinchè funzioni, fare un to lower anche sul campo db!
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

using Deliveriamo.DTOs.Product;
using Deliveriamo.DTOs.Register;
using Deliveriamo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    public class RegisterController : BaseApiController
    {
        private readonly IRegisterService _service;

        public RegisterController(IRegisterService registerService)
        {
            _service = registerService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(RegisterResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            RegisterResponseDto response = new RegisterResponseDto();
            try
            {
                response = await _service.AddUser(request);


            }
            catch (Exception ex)
            {
                response.SetExeption(ex.Message);
            }
            return new ObjectResult(response);
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(RegisterResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> RegisterShop([FromBody] RegisterShopRequestDto request)
        {
            RegisterResponseDto response = new RegisterResponseDto();
            try
            {
                response = await _service.AddUserShop(request);


            }
            catch (Exception ex)
            {
                response.SetExeption(ex.Message);
            }
            return new ObjectResult(response);
        }
    }
}

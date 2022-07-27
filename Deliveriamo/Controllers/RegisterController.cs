using Deliveriamo.DTOs.Register;
using Deliveriamo.Services.Interfaces;
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
    }
}

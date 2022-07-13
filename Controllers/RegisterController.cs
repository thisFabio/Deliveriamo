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
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _service.AddUser(request);
            return new ObjectResult(result);
        }
    }
}

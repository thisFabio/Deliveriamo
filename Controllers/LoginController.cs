using Deliveriamo.DTOs.Login;
using Deliveriamo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    public class LoginController : BaseApiController
    {
        private readonly ILoginService _service;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _service.Login(request);
            return new ObjectResult(result);
        }

    }
}

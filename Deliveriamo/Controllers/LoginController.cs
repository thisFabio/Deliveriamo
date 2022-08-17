using Deliveriamo.DTOs.Login;
using Deliveriamo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    public class LoginController : BaseApiController
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        //TODO aggiornare questo metodo affinchè funzioni, fare un to lower anche sul campo db!
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var result = await _service.Login(request);
            return new ObjectResult(result);
        }




    }
}

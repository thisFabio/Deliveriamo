
using Deliveriamo.DTOs.Product;
using Deliveriamo.DTOs.User;
using Deliveriamo.Services.Implementations;
using Deliveriamo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetAllUsersResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequestDto request)
        {
            var result = await _service.GetAllUsers(request);
            return new ObjectResult(result);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetUserResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> GetUserById([FromQuery] GetUserRequestDto request)
        {
            var result = await _service.GetUserById(request);
            return new ObjectResult(result);
        }

    }
}

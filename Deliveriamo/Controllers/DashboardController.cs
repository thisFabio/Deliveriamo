using Deliveriamo.DTOs.Dashboard;
using Deliveriamo.DTOs.Login;
using Deliveriamo.Services.Implementations;
using Deliveriamo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    public class DashboardController : BaseApiController
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        [HttpGet] //Action
        [ProducesResponseType(200,Type=typeof(GetShopKeepersResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.
        public async Task<IActionResult> GetShopKeepers([FromQuery] GetShopKeepersRequestDto request)
        {
            var result = await _service.GetShopKeepers(request);
            return new ObjectResult(result);
        }
    }
}

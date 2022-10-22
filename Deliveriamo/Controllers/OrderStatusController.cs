using Deliveriamo.DTOs.Dashboard;
using Deliveriamo.DTOs.Order;
using Deliveriamo.DTOs.Product;
using Deliveriamo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    
    public class OrderStatusController : BaseApiController
    {
        private readonly IOrderService _orderService;

        public OrderStatusController (IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetOrderStatusResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.
        public async Task<IActionResult> GetOrderStatus([FromQuery] GetOrderStatusRequestDto request)
        {
            var result = await _orderService.GetOrderStatus(request);
            return new ObjectResult(result);
        }



    }
}

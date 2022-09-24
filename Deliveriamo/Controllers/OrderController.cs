using Deliveriamo.DTOs.Dashboard;
using Deliveriamo.DTOs.Order;
using Deliveriamo.DTOs.Product;
using Deliveriamo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    
    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetAllOrdersResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersRequestDto request)
        {
            var userId = User.Claims.First(x => x.Type == "userid").Value;

            var result = await _orderService.GetAllOrders(request, userId);
            return new ObjectResult(result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AddOrderResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequestDto request)
        {
            var userId = User.Claims.First(x => x.Type == "userid").Value;
            var result = await _orderService.AddOrder(request, userId);
            return new ObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateOrderResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderRequestDto request)
        {
            var result = await _orderService.UpdateOrder(request);
            return new ObjectResult(result);
        }

        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(DeleteOrderResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.
        public async Task<IActionResult> DeleteOrder([FromBody] DeleteOrderRequestDto request)
        {
            var result = await _orderService.DeleteOrder(request);
            return new ObjectResult(result);
        }

    }
}

using Deliveriamo.DTOs.Order;

namespace Deliveriamo.Services.Interfaces
{
    public interface IOrderService
    {
        Task<AddOrderResponseDto> AddOrder(AddOrderRequestDto request, string userId);
        Task<UpdateOrderResponseDto> UpdateOrder(UpdateOrderRequestDto request);
        Task<DeleteOrderResponseDto> DeleteOrder(DeleteOrderRequestDto request);
        Task<GetAllOrdersResponseDto> GetAllOrders(GetAllOrdersRequestDto request, string userId);


    }
}

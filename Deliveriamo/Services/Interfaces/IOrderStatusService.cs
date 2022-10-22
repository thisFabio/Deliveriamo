using Deliveriamo.DTOs.Order;
using Deliveriamo.DTOs.OrderStatus;


namespace Deliveriamo.Services.Interfaces
{
    public interface IOrderStatusService
    {

        Task<PushForwardOrderStatusResponseDto> PushForwardStatus(PushForwardOrderStatusRequestDto request);
        Task<CancelOrderStatusResponseDto> CancelOrderStatus(CancelOrderStatusStatusRequestDto request);
        Task<GetOrderStatusResponseDto> GetOrderStatus( GetOrderStatusRequestDto request);

    }
}

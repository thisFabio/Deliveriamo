namespace Deliveriamo.DTOs.Order
{
    public class GetOrdersByUserIdResponseDto : BaseResponseDto
    {
        public List<OrderDto> Orders { get; set; }

    }
}

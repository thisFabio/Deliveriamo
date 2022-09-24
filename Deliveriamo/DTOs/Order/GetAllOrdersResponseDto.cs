namespace Deliveriamo.DTOs.Order
{
    public class GetAllOrdersResponseDto : BaseResponseDto
    {
        public List<OrderDto> Orders { get; set; }

    }
}

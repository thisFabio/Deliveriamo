using DeliveriamoRepository.Entity;

namespace Deliveriamo.DTOs.Order
{
    public class GetOrderStatusResponseDto
    {
        public string Status { get; set; }
        public DateTime StatusChangedTime { get; set; }
        public int OrderStatusId { get; set; }
    }
}

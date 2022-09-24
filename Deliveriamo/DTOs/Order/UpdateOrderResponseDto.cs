namespace Deliveriamo.DTOs.Order
{
    public class UpdateOrderResponseDto : BaseResponseDto
    {
        public int UserId { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderDescription { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public decimal DeliveryTime { get; set; }
        public string OrderStatus { get; set; }
    }
}

namespace Deliveriamo.DTOs.Order
{
    public class UpdateOrderRequestDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderDescription { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public decimal DeliveryTime { get; set; }
        public string OrderStatus { get; set; }
        public int ShopKeeperId { get; set; }
    }
}

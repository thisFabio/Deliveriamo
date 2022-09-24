using Deliveriamo.DTOs.Enums;
using Deliveriamo.DTOs.Product;

namespace Deliveriamo.DTOs.Order
{
    public class AddOrderRequestDto
    {

        public string PaymentMethod { get; set; }
        public string OrderDescription { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public decimal DeliveryTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<int> ProductIds { get; set; }

    }
}

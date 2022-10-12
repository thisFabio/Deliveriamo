using Deliveriamo.DTOs.Enums;
using Deliveriamo.DTOs.Product;

namespace Deliveriamo.DTOs.Order
{
    public class AddOrderRequestDto
    {

        public string PaymentMethod { get; set; }
        public string OrderDescription { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public List<int> ProductIds { get; set; }

        public int ShopKeeperId { get; set; }

    }
}

using Deliveriamo.DTOs.Enums;
using Deliveriamo.DTOs.Product;
using System.ComponentModel.DataAnnotations;

namespace Deliveriamo.DTOs.Order
{
    public class OrderDto
    {
        public OrderDto(int id, string paymentMethod, string orderDescription, decimal orderTotalAmount, DateTime? orderCreationDateTime, decimal deliveryTime, OrderStatus orderStatus, List<ProductDto> products)
        {
            Id = id;
            PaymentMethod = paymentMethod;
            OrderDescription = orderDescription;
            OrderTotalAmount = orderTotalAmount;
            OrderCreationDateTime = orderCreationDateTime;
            DeliveryTime = deliveryTime;
            OrderStatus = orderStatus;
            Products = products;
        }

        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderDescription { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public DateTime? OrderCreationDateTime { get; set; }
        public decimal DeliveryTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}

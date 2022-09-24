using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveriamoRepository.Entity
{
    public class Order
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderDescription { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public DateTime OrderCreationDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public decimal DeliveryTime { get; set; }
        public string  OrderStatus { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }


    }
}

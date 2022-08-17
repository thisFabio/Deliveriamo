using DeliveriamoRepository.Entity;

namespace Deliveriamo.DTOs.Product
{
    public class AddProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal PriceUnit { get; set; }
        public int CategoryId { get; set; }

        public string Barcode { get; set; }

        public string UrlImage { get; set; }

        public bool Status { get; set; }


    }
}

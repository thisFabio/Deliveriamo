namespace Deliveriamo.DTOs.Product
{
    public class ProductDto
    {
        public ProductDto(int id, string name, decimal priceUnit, string description, int categoryId, string barcode, string urlImage, bool status, DateTime? creationTime, DateTime? lastUpdate)
        {
            Id = id;
            Name = name;
            PriceUnit = priceUnit;
            Description = description;
            CategoryId = categoryId;
            Barcode = barcode;
            UrlImage = urlImage;
            Status = status;
            CreationTime = creationTime;
            LastUpdate = lastUpdate;
        }


        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PriceUnit { get; set; }

        public string Description { get; set; }
        public int CategoryId { get; set; }

        public string Barcode { get; set; }

        public string UrlImage { get; set; }

        public bool Status { get; set; } = true;


        public DateTime? CreationTime { get; set; }

        public DateTime? LastUpdate { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveriamoRepository.Entity
{
    public class Product
    {
        
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public decimal PriceUnit { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public string Barcode { get; set; }

        public string UrlImage { get; set; }

        public bool Status { get; set; } = true;

        public DateTime CreationTime { get; set; }

        public DateTime LastUpdate { get; set; }




    }
}

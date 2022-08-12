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
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string BarCode { get; set; }

    }
}

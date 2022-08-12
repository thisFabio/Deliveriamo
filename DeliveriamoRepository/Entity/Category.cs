using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveriamoRepository.Entity
{
    public class Category
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

        public List<Product> Products { get; set; } = new List<Product>();

    }
}

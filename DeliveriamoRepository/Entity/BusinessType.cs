using System.ComponentModel.DataAnnotations;


namespace DeliveriamoRepository.Entity
{
    public class BusinessType
    {
        [Required]

        public int Id { get; set; }
        [Required]
        public string BusinessTypeName { get; set; }
        [Required]
        public string BusinessTypeDescription { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace DeliveriamoRepository.Entity
{
    public class Role
    {
        //TODO : Fill properties
        [Required]
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}

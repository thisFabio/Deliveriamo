using System.ComponentModel.DataAnnotations;

namespace DeliveriamoRepository.Entity
{
    public class User
    {
        
        [Required]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Firstname { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Lastname { get; set; }
        [Required(AllowEmptyStrings = false)]  
        public DateTime Dob { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(1)]
        public char Gender { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}

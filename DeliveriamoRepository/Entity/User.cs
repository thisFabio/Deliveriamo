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
        [MaxLength(20)]
        [UIHint("NumberTemplate")]
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public bool ShopKeeper { get; set; } = false;
        public string CompanyName { get; set; }
        public string BusinessName { get; set; }
        public string VatNumber { get; set; }
        public string CompanyStreetAddress { get; set; }
        public string CompanyCivicNumber { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyPostalCode { get; set; }




    }
}

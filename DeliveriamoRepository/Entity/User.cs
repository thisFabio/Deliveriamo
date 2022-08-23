using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveriamoRepository.Entity
{
    public class User
    {
        
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [ForeignKey("BusinessTypeName")]
        public string BusinessTypeName { get; set; }
        public string ExtendedCompanyName { get; set; }
        public string BusinessName { get; set; }
        public string VatNumber { get; set; }
        public string CompanyStreetAddress { get; set; }
        public string CompanyCivicNumber { get; set; }
        public string CompanyPostalCode { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyCountry { get; set; }
        public string ImageUrl { get; set; }

        public int? ShopKeeperTypeId { get; set; }





    }
}

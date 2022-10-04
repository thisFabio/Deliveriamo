using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveriamoRepository.Entity
{
    public class UserAddress
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string UserStreetAddress { get; set; }
        public string UserCivicNumber { get; set; }
        public string UserPostalCode { get; set; }
        public string UserCity { get; set; }
        public string UserCountry { get; set; }



    }
}

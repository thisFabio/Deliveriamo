using DeliveriamoRepository.Entity;

namespace Deliveriamo.DTOs.User
{
    public class UpdateUserRequestDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Dob { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public int RoleId { get; set; }
        public bool Enabled { get; set; }
        public Role Role { get; set; }
        public bool ShopKeeper { get; set; } = false;
        public string BusinessTypeName { get; set; }
        public string ExtendedCompanyName { get; set; }
        public string BusinessName { get; set; }
        public string VatNumber { get; set; }
        public string CompanyStreetAddress { get; set; }
        public string CompanyCivicNumber { get; set; }
        public string CompanyPostalCode { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyCountry { get; set; }
    }
}

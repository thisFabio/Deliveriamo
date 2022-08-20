using DeliveriamoRepository.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Deliveriamo.DTOs.User
{
    public class UserDto : UsersDto
    {
        public UserDto(int id, string username, string firstname, string lastname, DateTime dob, char gender, string phoneNumber, int roleId, bool enabled, Role role, bool shopKeeper, string businessTypeName, string extendedCompanyName, string businessName, string vatNumber, string companyStreetAddress, string companyCivicNumber, string companyPostalCode, string companyCity, string companyCountry) : base(id, username, firstname, lastname)
        {
            Dob = dob;
            Gender = gender;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
            Enabled = enabled;
            Role = role;
            ShopKeeper = shopKeeper;
            BusinessTypeName = businessTypeName;
            ExtendedCompanyName = extendedCompanyName;
            BusinessName = businessName;
            VatNumber = vatNumber;
            CompanyStreetAddress = companyStreetAddress;
            CompanyCivicNumber = companyCivicNumber;
            CompanyPostalCode = companyPostalCode;
            CompanyCity = companyCity;
            CompanyCountry = companyCountry;
        }

        public DateTime Dob { get; set; }

        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
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

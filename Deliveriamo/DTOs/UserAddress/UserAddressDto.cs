namespace Deliveriamo.DTOs.UserAddress
{
    public class UserAddressDto
    {
        public UserAddressDto(int id, int userId, string userStreetAddress, string userCivicNumber, string userPostalCode, string userCity, string userCountry)
        {
            Id = id;
            UserId = userId;
            UserStreetAddress = userStreetAddress;
            UserCivicNumber = userCivicNumber;
            UserPostalCode = userPostalCode;
            UserCity = userCity;
            UserCountry = userCountry;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserStreetAddress { get; set; }
        public string UserCivicNumber { get; set; }
        public string UserPostalCode { get; set; }
        public string UserCity { get; set; }
        public string UserCountry { get; set; }
    }
}

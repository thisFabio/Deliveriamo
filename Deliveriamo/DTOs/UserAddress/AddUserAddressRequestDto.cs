﻿namespace Deliveriamo.DTOs.UserAddress
{
    public class AddUserAddressRequestDto
    {
        
        public string UserStreetAddress { get; set; }
        public string UserCivicNumber { get; set; }
        public string UserPostalCode { get; set; }
        public string UserCity { get; set; }
        public string UserCountry { get; set; }
    }
}

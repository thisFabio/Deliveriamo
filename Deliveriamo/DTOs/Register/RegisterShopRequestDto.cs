namespace Deliveriamo.DTOs.Register
{
    public class RegisterShopRequestDto : RegisterRequestDto
    {
        public bool ShopKeeper { get; set; } = true;
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

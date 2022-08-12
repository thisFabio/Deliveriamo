using Deliveriamo.DTOs.Login;
using Deliveriamo.DTOs.Register;
using Deliveriamo.DTOs.User;
using DeliveriamoRepository.Entity;
namespace Deliveriamo.DTOs
{
    public static class ExtensionsMethods
    {

        public static DeliveriamoRepository.Entity.User ToEntity(this RegisterRequestDto request, string hashedPassword)
        {
            DeliveriamoRepository.Entity.User user = null;
            try
            {
                if (String.IsNullOrEmpty(request.Username) ||
                String.IsNullOrEmpty(request.Password) ||
                String.IsNullOrEmpty(request.Firstname) ||
                String.IsNullOrEmpty(request.Lastname) ||
                !(request.Dob <= DateTime.Now && request.Dob >= new DateTime(1900,1,1)) ||
                !Char.IsLetter(request.Gender))
                {
                    return user;
                }
                user = new DeliveriamoRepository.Entity.User()
                {
                    Username = request.Username.ToLower(),
                    Password = hashedPassword,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Dob = Convert.ToDateTime(request.Dob),
                    RoleId = 2,
                    //Role = new Role() { Id = 2, RoleName = "user" },
                    Gender = request.Gender,
                    Enabled = true
                };
            }
            catch (Exception ex)
            {

                    
            }
            
            return user;
        }

        public static DeliveriamoRepository.Entity.User ToEntity(this RegisterShopRequestDto request, string hashedPassword)
        {
            DeliveriamoRepository.Entity.User user = null;
            try
            {
                if (
                String.IsNullOrEmpty(request.Username) ||
                String.IsNullOrEmpty(request.Password) ||
                String.IsNullOrEmpty(request.Firstname) ||
                String.IsNullOrEmpty(request.Lastname) ||
                !(request.Dob <= DateTime.Now && request.Dob >= new DateTime(1900, 1, 1)) ||
                !Char.IsLetter(request.Gender) ||
                String.IsNullOrEmpty(request.BusinessTypeName) ||
                String.IsNullOrEmpty(request.ExtendedCompanyName) ||
                String.IsNullOrEmpty(request.BusinessName) ||
                String.IsNullOrEmpty(request.PhoneNumber) ||
                String.IsNullOrEmpty(request.VatNumber) ||
                String.IsNullOrEmpty(request.CompanyStreetAddress) ||
                String.IsNullOrEmpty(request.CompanyCivicNumber) ||
                String.IsNullOrEmpty(request.CompanyPostalCode) ||
                String.IsNullOrEmpty(request.CompanyCity) ||
                String.IsNullOrEmpty(request.CompanyCountry))


                {
                    return user;
                }
                user = new DeliveriamoRepository.Entity.User()
                {
                    Username = request.Username.ToLower(),
                    Password = hashedPassword,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Dob = Convert.ToDateTime(request.Dob),
                    RoleId = 2,
                    //Role = new Role() { Id = 2, RoleName = "user" },
                    Gender = request.Gender,
                    Enabled = true,
                    ShopKeeper = true,
                    BusinessTypeName = request.BusinessTypeName,
                    ExtendedCompanyName = request.ExtendedCompanyName,
                    BusinessName = request.BusinessName,
                    PhoneNumber = request.PhoneNumber,
                    VatNumber = request.VatNumber,
                    CompanyStreetAddress = request.CompanyStreetAddress,
                    CompanyCivicNumber = request.CompanyCivicNumber,
                    CompanyPostalCode = request.CompanyPostalCode,
                    CompanyCountry = request.CompanyCountry,
                    CompanyCity = request.CompanyCity
                };
            }
            catch (Exception ex)
            {


            }

            return user;
        }

        public static RegisterRequestDto FixRegisterRequestToLower(this RegisterRequestDto request)
        {
            return new RegisterRequestDto()
            {
                Username = request.Username.ToLower(),
                Password = request.Password,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Gender = char.Parse(request.Gender.ToString().ToLower()),
                Dob = request.Dob

            };

        }

        public static LoginRequestDto FixLoginRequestToLower(this LoginRequestDto request)
        {
            return new LoginRequestDto()
            {
                Username = request.Username.ToLower(),
                Password = request.Password

            };

        
        }

        public static AddUserRequestDto FixAddUserRequestToLower(this AddUserRequestDto request)
        {
            return new AddUserRequestDto()
            {
                Username = request.Username.ToLower(),
                Password = request.Password,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Gender = char.Parse(request.Gender.ToString().ToLower()),
                Dob = request.Dob,
                Role = request.Role

            };

           
        }
    }
}

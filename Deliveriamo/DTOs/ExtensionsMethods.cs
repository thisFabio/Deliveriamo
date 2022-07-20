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
            return new DeliveriamoRepository.Entity.User()
            {
                Username = request.Username.ToLower(),
                Password = hashedPassword,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Dob = Convert.ToDateTime(request.Dob),
                RoleId = 2,
                Gender = request.Gender,
                Enabled = true
            };
        }

        public static RegisterRequestDto FixRegisterRequestToLower(RegisterRequestDto request)
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

        public static LoginRequestDto FixLoginRequestToLower(LoginRequestDto request)
        {
            return new LoginRequestDto()
            {
                Username = request.Username.ToLower(),
                Password = request.Password

            };

        
        }

        public static AddUserRequestDto FixAddUserRequestToLower(AddUserRequestDto request)
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

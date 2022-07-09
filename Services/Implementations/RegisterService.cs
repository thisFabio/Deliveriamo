using Deliveriamo.DTOs.Register;
using Deliveriamo.Entity;
using Deliveriamo.Services.Interfaces;


namespace Deliveriamo.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly ICryptoService _CryptoService;

        async Task<RegisterResponse> IRegisterService.AddUser(RegisterRequest request)
        {
            var response = new RegisterResponse();
            

            User user = new User()
            {
                Username = request.Username,
                Password = _CryptoService.CreateMD5(request.Password),
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Dob = Convert.ToDateTime(request.Dob),
                Role = 2,
                Gender = request.Gender,
                Enabled = true


            };

            //TODO: save user into DB

            response.Id = user.Id;
            return response;
        }
    }
}

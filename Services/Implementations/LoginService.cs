using Deliveriamo.ViewModels.Login;
using Deliveriamo.Services.Interfaces;

namespace Deliveriamo.Services.Implementations
{
    public class LoginService : ILoginService
    {
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var output = new LoginResponse();


            return output;
        }

        private string GenerateToken()
        {
            var token = string.Empty;

            return token;
        }
    }
}

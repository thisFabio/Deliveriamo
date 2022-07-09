using Deliveriamo.DTOs.Login;
using Deliveriamo.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Deliveriamo.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly ICryptoService _cryptoService;

        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var output = new LoginResponse();

            // if credential provided are not null
            if (request.Username != null && request.Password != null)
            {
                // hashing of password provided
                var hash = _cryptoService.CreateMD5(request.Password);
                // TODO:look into DB to see if username and password are valid (compare pwd with hash),
                // else return empt obj

                // TODO: if there is association, generate token

            }

            return output;
        }

        private string GenerateToken()
        {
            var result = string.Empty;
            var tokenHandler = new JwtSecurityTokenHandler();
            // prendo la chiave che ho definito
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue(typeof(string), "JwtEncryptionKey").ToString());

            // definisco dei descrittori chiamati CLAIM che definiscono il token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userid","1"),
                    new Claim(ClaimTypes.Role, "Admin") // ruolo definito 
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            result = tokenHandler.WriteToken(token).ToString();

            return result;
        }
    }
}

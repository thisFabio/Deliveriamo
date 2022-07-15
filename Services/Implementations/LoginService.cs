using Deliveriamo.DTOs.Login;
using Deliveriamo.Entity;
using Deliveriamo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        private readonly DeliveriamoContext _context;

        public LoginService(IConfiguration configuration, DeliveriamoContext context, ICryptoService cryptoService = null)
        {
            _configuration = configuration;
            _context = context;
            _cryptoService = cryptoService;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto request)
        {
            var output = new LoginResponseDto();
            User user = new User();

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return output;
            }


            // if credential provided are not null

            // hashing of password provided
            var hash = _cryptoService.CreateMD5(request.Password);

            // look into DB to see if username and password are valid (compare pwd with hash),
            user = await _context.User.FirstOrDefaultAsync(x => x.Username == request.Username && x.Password == hash);

            if (user != null)
            {
                // if there is association, generate token
                output.Token = GenerateToken(user.Role.Id.ToString());
               
            };

            // else return empt obj


            return output;
        }

        private string GenerateToken(string role)
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
                    new Claim(ClaimTypes.Role, role) // ruolo definito TODO: Fix the role 
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

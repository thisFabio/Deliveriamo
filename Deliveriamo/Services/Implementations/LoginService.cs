﻿using Deliveriamo.DTOs.Login;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;
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
        private readonly IRepositoryService _repository;

        public LoginService(IConfiguration configuration, IRepositoryService repository, ICryptoService cryptoService = null)
        {
            _configuration = configuration;
            _repository = repository;
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
            var hash = _cryptoService.CreateMD5(request.Password).ToLower();

            // look into DB to see if username and password are valid (compare pwd with hash),
            user = await _repository.CheckLogin(request.Username, hash);

            if (user != null)
            {
                // if there is association, generate token
                output.Token = GenerateToken(user.Role?.Id.ToString(), user.Id.ToString());
               
            };

            // else return empt obj

            return output;
        }

        private string GenerateToken(string role, string id)
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
                    
                    new Claim("userid",id),
                    new Claim(ClaimTypes.Role, role) 
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

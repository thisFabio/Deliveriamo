using Deliveriamo.DTOs;
using Deliveriamo.DTOs.Register;
using Deliveriamo.Services.Exceptions;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;

namespace Deliveriamo.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly ICryptoService _CryptoService;
        private readonly IRepositoryService _repository;

        public RegisterService(ICryptoService cryptoService, IRepositoryService repository)
        {
            _CryptoService = cryptoService;
            _repository = repository;
        }

        public async Task<RegisterResponseDto> AddUser(RegisterRequestDto request)
        {
            
            var response = new RegisterResponseDto();
            if(await _repository.UsernameAlreadyExist(request.Username))
            {
                throw new UserAlreadyExistException($"username {request.Username} already exist.");
            }
            //new RegisterRequestDto.FixRegisterRequestToLower()

            var hashedPassword = _CryptoService.CreateMD5(request.Password);
            User user = request.ToEntity(hashedPassword);
            if (user != null)
            {
                try
                {

                    await _repository.AddUser(user);
                    await _repository.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                
               
               
                response.Id = user.Id;

            }
            //save user into DB

            return response;
        }

        public async Task<RegisterResponseDto> AddUserShop(RegisterShopRequestDto request)
        {
            var response = new RegisterResponseDto();
            if (await _repository.UsernameAlreadyExist(request.Username))
            {
                throw new UserAlreadyExistException($"username {request.Username} already exist.");
            }
            var hashedPassword = _CryptoService.CreateMD5(request.Password);
            User user = request.ToEntity(hashedPassword);
            if (user != null)
            {
                await _repository.AddUser(user);
                await _repository.SaveChanges();
                response.Id = user.Id;
            }
            return response;

        }
    }
}

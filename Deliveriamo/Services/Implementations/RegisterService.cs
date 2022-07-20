using Deliveriamo.DTOs;
using Deliveriamo.DTOs.Register;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;

namespace Deliveriamo.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly ICryptoService _CryptoService;
        private readonly IRepository _repository;

        public RegisterService(ICryptoService cryptoService, IRepository repository)
        {
            _CryptoService = cryptoService;
            _repository = repository;
        }

        public async Task<RegisterResponseDto> AddUser(RegisterRequestDto request)
        {
            
            var response = new RegisterResponseDto();
            var hashedPassword = _CryptoService.CreateMD5(request.Password);
            User user = request.ToEntity(hashedPassword);

            //save user into DB
            await _repository.AddUser(user);
            await _repository.SaveChanges();

            response.Id = user.Id;
            return response;
        }


        
    }
}

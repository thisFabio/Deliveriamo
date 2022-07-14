using Deliveriamo.DTOs.Register;
using Deliveriamo.Entity;
using Deliveriamo.Services.Interfaces;


namespace Deliveriamo.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly ICryptoService _CryptoService;
        private readonly DeliveriamoContext _context;

        public RegisterService(ICryptoService cryptoService, DeliveriamoContext context)
        {
            _CryptoService = cryptoService;
            _context = context;
        }

        public async Task<RegisterResponse> AddUser(RegisterRequestDto request)
        {
            var response = new RegisterResponse();
            

            User user = new User()
            {
                Username = request.Username,
                Password = _CryptoService.CreateMD5(request.Password),
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Dob = Convert.ToDateTime(request.Dob),
                RoleId = 2,
                Gender = request.Gender,
                Enabled = true
            };

            //save user into DB
            await _context.User.AddAsync(user);
            _context.SaveChanges();

            response.Id = user.Id;
            return response;
        }
    }
}

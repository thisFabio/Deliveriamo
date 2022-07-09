using Deliveriamo.DTOs.Register;

namespace Deliveriamo.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<RegisterResponse> AddUser(RegisterRequest request);
    }
}

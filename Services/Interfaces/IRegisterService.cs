using Deliveriamo.DTOs.Register;

namespace Deliveriamo.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<RegisterResponseDto> AddUser(RegisterRequestDto request);
    }
}

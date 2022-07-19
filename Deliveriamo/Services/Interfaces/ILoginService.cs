using Deliveriamo.DTOs.Login;

namespace Deliveriamo.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseDto> Login(LoginRequestDto request);
    }
}

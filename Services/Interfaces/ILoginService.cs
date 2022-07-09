using Deliveriamo.ViewModels.Login;

namespace Deliveriamo.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}

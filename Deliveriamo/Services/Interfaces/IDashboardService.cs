using Deliveriamo.DTOs.Dashboard;

namespace Deliveriamo.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<GetShopKeepersResponseDto> GetShopKeepers(GetShopKeepersRequestDto request);
    }
}

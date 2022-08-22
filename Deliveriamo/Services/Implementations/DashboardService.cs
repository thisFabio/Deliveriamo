using Deliveriamo.DTOs.Dashboard;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;

namespace Deliveriamo.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IRepositoryService _repo;

        public DashboardService(IRepositoryService repo)
        {
            _repo = repo;
        }

        public async Task<GetShopKeepersResponseDto> GetShopKeepers(GetShopKeepersRequestDto request)
        {
            var response = new GetShopKeepersResponseDto();

            var shopKeepers = await _repo.GetAllShopKeepers();

            response.ShopKeepers = shopKeepers.Select(x => new ShopKeeperDto()
            {
                Id = x.Id,
                Name = x.BusinessName,
                CompanyStreetAddress = x.CompanyStreetAddress
            }).ToList();


            return response;
        }
    }

}

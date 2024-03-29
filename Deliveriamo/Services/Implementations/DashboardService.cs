﻿using Deliveriamo.DTOs.Dashboard;
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
            if (request.IsRestaurant == true)
            {
                response.ShopKeepers = shopKeepers
                    .Where(x => (String.IsNullOrEmpty(request.ShopKeeperName) || x.BusinessName.ToLower().Contains(request.ShopKeeperName.ToLower()) ||
                    x.CompanyStreetAddress.ToLower().Contains(request.ShopKeeperName.ToLower()) || x.CompanyCity.ToLower().Contains(request.ShopKeeperName.ToLower()))
                    && x.BusinessTypeId==1)
                    .Select(x => new ShopKeeperDto()
                    {
                        Id = x.Id,
                        Name = x.BusinessName,
                        CompanyStreetAddress = x.CompanyStreetAddress,
                        ImageUrl = x.ImageUrl
                    }).ToList();
            }
            else if(request.IsSupermarket == true)
            {
                response.ShopKeepers = shopKeepers
                    .Where(x => (String.IsNullOrEmpty(request.ShopKeeperName) || x.BusinessName.ToLower().Contains(request.ShopKeeperName.ToLower()) ||
                    x.CompanyStreetAddress.ToLower().Contains(request.ShopKeeperName.ToLower()) || x.CompanyCity.ToLower().Contains(request.ShopKeeperName.ToLower()))
                    && x.BusinessTypeId == 2)
                    .Select(x => new ShopKeeperDto()
                    {
                        Id = x.Id,
                        Name = x.BusinessName,
                        CompanyStreetAddress = x.CompanyStreetAddress,
                        ImageUrl = x.ImageUrl
                    }).ToList();

            }
            else
            {
                response.ShopKeepers = shopKeepers
                    .Where(x => String.IsNullOrEmpty(request.ShopKeeperName) || x.BusinessName.ToLower().Contains(request.ShopKeeperName.ToLower()) ||
                    x.CompanyStreetAddress.ToLower().Contains(request.ShopKeeperName.ToLower()) || x.CompanyCity.ToLower().Contains(request.ShopKeeperName.ToLower()))
                    .Select(x => new ShopKeeperDto()
                    {
                        Id = x.Id,
                        Name = x.BusinessName,
                        CompanyStreetAddress = x.CompanyStreetAddress,
                        ImageUrl = x.ImageUrl
                    }).ToList();
            }


            return response;
        }
    }

}

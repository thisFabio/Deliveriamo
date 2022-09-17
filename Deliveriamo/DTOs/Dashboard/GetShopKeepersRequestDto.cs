namespace Deliveriamo.DTOs.Dashboard
{
    public class GetShopKeepersRequestDto
    {
        public string ShopKeeperName { get; set; }

        public bool IsRestaurant { get; set; }
        public bool IsSupermarket { get; set; }


    }
}
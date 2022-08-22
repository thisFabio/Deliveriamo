namespace Deliveriamo.DTOs.Dashboard
{
    public class GetShopKeepersResponseDto : BaseResponseDto
    {
        public List<ShopKeeperDto> ShopKeepers { get; set; }
    }
}
namespace Deliveriamo.DTOs.UserAddress
{
    public class GetUserAddressByIdResponseDto : BaseResponseDto
    {
        public List<UserAddressDto> UserAddress { get; set; }
    }
}

using Deliveriamo.DTOs.Product;

namespace Deliveriamo.DTOs.User
{
    public class GetUserResponseDto : BaseResponseDto
    {
        public List<UsersDto> Users { get; set; }

    }
}

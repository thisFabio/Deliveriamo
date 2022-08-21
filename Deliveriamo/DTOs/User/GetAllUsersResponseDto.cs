namespace Deliveriamo.DTOs.User
{
    public class GetAllUsersResponseDto : BaseResponseDto
    {
        public List<UsersDto> Users { get; set; }
    }
}

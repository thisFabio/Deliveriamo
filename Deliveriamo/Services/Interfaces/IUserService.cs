using Deliveriamo.DTOs.User;

namespace Deliveriamo.Services.Interfaces
{
    public interface IUserService
    {
        Task<GetAllUsersResponseDto> GetAllUsers(GetAllUsersRequestDto request);
        Task<GetUserResponseDto> GetUserById(GetUserAddressRequestDto request);
        Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto request);
        Task<DeleteUserResponseDto > DeleteUser(DeleteUserRequestDto request);



    }
}

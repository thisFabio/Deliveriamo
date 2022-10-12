using Deliveriamo.DTOs.User;

namespace Deliveriamo.Services.Interfaces
{
    public interface IUserService 
    {
        Task<GetAllUsersResponseDto> GetAllUsers(GetAllUsersRequestDto request);
        Task<GetUserResponseDto> GetUserById(GetUserRequestDto request);

        Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto request);
        Task<DeleteUserResponseDto > DeleteUser(DeleteUserRequestDto request);



    }
}

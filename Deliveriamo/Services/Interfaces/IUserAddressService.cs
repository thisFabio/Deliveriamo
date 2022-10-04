
using Deliveriamo.DTOs.UserAddress;

namespace Deliveriamo.Services.Interfaces
{
    public interface IUserAddressService
    {
        Task<GetUserAddressByIdResponseDto> GetUserAddressListByUserId(GetUserAddressByIdRequestDto request); 
        Task<AddUserAddressResponseDto> AddUserAddress(AddUserAddressRequestDto request, string userId);
        Task<UpdateUserAddressResponseDto> UpdateUserAddress(UpdateUserAddressRequestDto request);
        Task<DeleteUserAddressResponseDto> DeleteUserddress(DeleteUserAddressRequestDto request);



    }
}

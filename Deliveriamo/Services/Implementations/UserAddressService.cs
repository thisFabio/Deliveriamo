using Deliveriamo.DTOs;
using Deliveriamo.DTOs.Register;
using Deliveriamo.DTOs.User;
using Deliveriamo.DTOs.UserAddress;
using Deliveriamo.Services.Exceptions;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;

namespace Deliveriamo.Services.Implementations
{
    public class UserAddressService : IUserAddressService
    {

        private readonly IRepositoryService _repository;

        public UserAddressService(IRepositoryService repository)
        {

            _repository = repository;
        }
       
        public async Task<GetUserAddressByIdResponseDto> GetUserAddressListByUserId(GetUserAddressByIdRequestDto request)
        {
            var result = new GetUserAddressByIdResponseDto();
            result.UserAddress = new List<UserAddressDto>();

            var dbUserAddressesList = await _repository.GetUserAddressListByUserId(request.Id);

            if (dbUserAddressesList.Count() == 0)
            {
                throw new Exception($"User Addresses of User: {request.Id} not found");

            }
            
            result.UserAddress = dbUserAddressesList.Select(x=> new UserAddressDto(
                
                x.Id,
                x.UserId,
                x.UserStreetAddress,
                x.UserCivicNumber,
                x.UserPostalCode,
                x.UserCity,
                x.UserCountry
                
                )).ToList();

            return result;
        }

        public async Task<AddUserAddressResponseDto> AddUserAddress(AddUserAddressRequestDto request, string userId)
        {
            var result = new AddUserAddressResponseDto();

            if (Int32.Parse(userId) <= 0 || String.IsNullOrEmpty(request.UserStreetAddress) || String.IsNullOrEmpty(request.UserCivicNumber) ||
                String.IsNullOrEmpty(request.UserPostalCode) || String.IsNullOrEmpty(request.UserCity) || String.IsNullOrEmpty(request.UserCountry))
            {
                throw new Exception($"Impossible to Add this Address, invalid data entry.");

            }

            UserAddress userAddress = new UserAddress()
            {
                UserId = Int32.Parse(userId),
                UserStreetAddress = request.UserStreetAddress,
                UserCivicNumber = request.UserCivicNumber,
                UserPostalCode = request.UserPostalCode,
                UserCity = request.UserCity,
                UserCountry = request.UserCountry
            };
            if (userAddress != null)
            {
                try
                {
                    await _repository.AddUserAddress(userAddress);
                    await _repository.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }    
                
            return result;
                
        }

        public async Task<UpdateUserAddressResponseDto> UpdateUserAddress(UpdateUserAddressRequestDto request)
        {
            var result = new UpdateUserAddressResponseDto();

            var userAddress = await _repository.GetUserAddressById(request.Id);

            if (userAddress == null)
            {
                throw new Exception($"User Address: {request.Id} not found.");

            }

            userAddress.UserId = request.UserId;
            userAddress.UserStreetAddress = request.UserStreetAddress;
            userAddress.UserCivicNumber = request.UserCivicNumber;
            userAddress.UserPostalCode = request.UserPostalCode;
            userAddress.UserCity = request.UserCity;
            userAddress.UserCountry = request.UserCountry;

            await _repository.UpdateUserAddress(userAddress);
            await _repository.SaveChanges();

            result.UserId = userAddress.UserId;
            result.UserStreetAddress = userAddress.UserStreetAddress;
            result.UserCivicNumber = userAddress.UserCivicNumber;
            result.UserPostalCode = userAddress.UserPostalCode;
            result.UserCity = userAddress.UserCity;
            result.UserCountry = userAddress.UserCountry;


            return result;
        }

        public async Task<DeleteUserAddressResponseDto> DeleteUserddress(DeleteUserAddressRequestDto request)
        {
            var result = new DeleteUserAddressResponseDto();

            var userAddress = await _repository.GetUserAddressById(request.Id);

            if (userAddress == null)
            {
                throw new Exception($"User Address: {request.Id} not found.");

            }

            await _repository.DeleteUserAddress(userAddress);
            await _repository.SaveChanges();

            result.Id = userAddress.Id;

            return result;
        }
    }
}

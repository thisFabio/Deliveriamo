using Deliveriamo.DTOs;
using Deliveriamo.DTOs.Register;
using Deliveriamo.DTOs.User;
using Deliveriamo.Services.Exceptions;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;

namespace Deliveriamo.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IRepositoryService _repository;

        public UserService(IRepositoryService repository)
        {

            _repository = repository;
        }

        public async Task<GetAllUsersResponseDto> GetAllUsers(GetAllUsersRequestDto request)
        {
            var result = new GetAllUsersResponseDto();

            var dbResponse = await _repository.GetUsers();

            result.Users =  dbResponse.Select(x => new UsersDto(
                x.Id,
                x.Username,
                x.Firstname,
                x.Lastname,
                x.ImageUrl
            )).ToList();

            return result;
        }
        public async Task<GetUserResponseDto> GetUserById(GetUserRequestDto request)
        {
            var result = new GetUserResponseDto();
            result.Users = new List<UsersDto>();

            var dbUser = await _repository.GetUserById(request.Id);

            if (dbUser == null)
            {
                throw new Exception($"User {request.Id} not found");
            }
            var user = new UsersDto(dbUser.Id, dbUser.Username, dbUser.Firstname, dbUser.Lastname, dbUser.ImageUrl);
            
            result.Users.Add(user);

            return result;
        }

        public async Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto request)
        {
            var result = new UpdateUserResponseDto();
            
            var user = await _repository.GetUserById(request.Id);

            if (user == null)
            {
                throw new Exception($"User {request.Id} not found");
            }


                user.Id = request.Id;
                user.Username = request.Username;
                user.Firstname = request.Firstname;
                user.Lastname = request.Lastname;
                user.ImageUrl = request.ImageUrl;
                user.Dob = request.Dob;
                user.Gender = request.Gender;
                user.PhoneNumber = request.PhoneNumber;
                user.Role = request.Role;
                user.RoleId = request.RoleId;
                user.Enabled = request.Enabled;
                user.ShopKeeper = request.ShopKeeper;
                user.BusinessTypeId = request.BusinessTypeId;
                user.BusinessName = request.BusinessName;
                user.ExtendedCompanyName = request.ExtendedCompanyName;
                user.VatNumber = request.VatNumber;
                user.CompanyStreetAddress = request.CompanyStreetAddress;
                user.CompanyCivicNumber = request.CompanyCivicNumber;
                user.CompanyCity = request.CompanyCity;
                user.CompanyCountry = request.CompanyCountry;
                user.CompanyPostalCode = request.CompanyPostalCode;

                
                _repository.UpdateUser(user);
                _repository.SaveChanges();


                result.Username = user.Username;
                result.Firstname = user.Firstname;
                result.Lastname = user.Lastname;
                result.ImageUrl = user.ImageUrl;
                result.Dob = user.Dob;
                result.Gender = user.Gender;
                result.PhoneNumber = user.PhoneNumber;
                result.Role = user.Role;
                result.RoleId = user.RoleId;
                result.Enabled = user.Enabled;
                result.ShopKeeper = user.ShopKeeper;
                result.BusinessTypeId= user.BusinessTypeId;
                result.BusinessName = user.BusinessName;
                result.ExtendedCompanyName = user.ExtendedCompanyName;
                result.VatNumber = user.VatNumber;
                result.CompanyStreetAddress = user.CompanyStreetAddress;
                result.CompanyCivicNumber = user.CompanyCivicNumber;
                result.CompanyCity = user.CompanyCity;
                result.CompanyCountry = user.CompanyCountry;
                result.CompanyPostalCode = user.CompanyPostalCode;


            return result;
        }


        public async Task<DeleteUserResponseDto> DeleteUser(DeleteUserRequestDto request)
        {
            var response = new DeleteUserResponseDto();

            var user = await _repository.GetUserById(request.Id);
            if (user == null)
            {
                throw new Exception($"User {request.Id} not found");
            }

            await _repository.DeleteUser(user);
            await _repository.SaveChanges();
            response.Id = user.Id;
            return response;
        }


    }
}

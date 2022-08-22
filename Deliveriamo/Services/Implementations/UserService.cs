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
    }
}

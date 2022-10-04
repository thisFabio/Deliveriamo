
using Deliveriamo.DTOs.Product;
using Deliveriamo.DTOs.User;
using Deliveriamo.DTOs.UserAddress;
using Deliveriamo.Services.Implementations;
using Deliveriamo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deliveriamo.Controllers
{
    public class UserAddressController : BaseApiController
    {
        private readonly IUserAddressService _service;

        public UserAddressController(IUserAddressService userAddressService)
        {
            _service = userAddressService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetUserAddressByIdResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> GetUserAddressListByUserId([FromQuery] GetUserAddressByIdRequestDto request)
        {
            GetUserAddressByIdResponseDto result = new();
            try
            {
                result = await _service.GetUserAddressListByUserId(request);

            }
            catch (Exception ex)
            {

                result.SetExeption(ex.Message);
            }
            return new ObjectResult(result);
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AddUserAddressResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.

        public async Task<IActionResult> AddUserAddress([FromBody] AddUserAddressRequestDto request)
        {
            var userId = User.Claims.First(x => x.Type == "userid").Value;
            var result = await _service.AddUserAddress(request, userId);
            return new ObjectResult(result);
        }



        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateUserAddressResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.
        public async Task<IActionResult> UpdateUserAddress([FromBody] UpdateUserAddressRequestDto request)
        {
            var result = await _service.UpdateUserAddress(request);
            return new ObjectResult(result);
        }

        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(DeleteUserAddressResponseDto))] // indicazione per swagger che indica il tipo di risposta di questa response.
        public async Task<IActionResult> DeleteUserAddress([FromBody] DeleteUserAddressRequestDto request)
        {
            var result =  await _service.DeleteUserddress(request);
            return new ObjectResult(result);
        }
    }
}

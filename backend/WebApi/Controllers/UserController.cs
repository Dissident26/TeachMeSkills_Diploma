using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using Services.Models;
using WebApi.Constants;

namespace WebApi
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet]
        [Route(RouteConstants.Get)]
        public async Task<UserDto> GetUser(int id)
        {
            return await _userServices.Get(id);
        }

        [HttpPost]
        [Route(RouteConstants.PostById)]
        public async Task<List<UserDto>> GetUser([FromBody] GetByIdsRequest request)
        {
            return await _userServices.Get(request.Ids);
        }
        [HttpGet]
        [Route(RouteConstants.GetList)]
        public async Task<List<UserDto>> GetUsersList()
        {
            return await _userServices.GetList();
        }
        [HttpPost]
        [Route(RouteConstants.Add)]
        public async Task<UserDto> AddUser([FromBody] UserDto user)
        {
            return await _userServices.Create(user);
        }
        [HttpPut]
        [Route(RouteConstants.Update)]
        public async Task<UserDto> UpdateUser([FromBody] UserDto user)
        {
            return await _userServices.Update(user);
        }
        [HttpDelete]
        [Route(RouteConstants.Delete)]
        public async Task<UserDto> DeleteUser(int id)
        {
            return await _userServices.Delete(id);
        }
    }
}
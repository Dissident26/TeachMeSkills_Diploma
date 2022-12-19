using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Services.Dtos;
using Services.Interfaces;
using Authentication.Constants;
using Authentication.Helpers;
using WebApi.Constants;

namespace WebApi.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly IUserServices _userServices;
        public AuthController(IAuthServices authServices, IUserServices userServices)
        {
            _authServices = authServices;
            _userServices = userServices;
        }
        [HttpPost]
        [Route(RouteConstants.SingIn)]
        public async Task<string> SignIn(UserAuthModelDto userAuthModel)
        {
            var user = await _authServices.ValidateUser(userAuthModel);
            List<Claim> claims = new() { new Claim(AuthConstants.ClaimType, user.Id.ToString()) };//???
            var token = JwtToken.GetToken(claims);
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedToken;
        }
        [HttpPost]
        [Route(RouteConstants.SingUp)]
        public async Task SignUp(UserAuthModelDto userAuthModel)
        {
            var user = await _userServices.Create(new UserDto
            {
                Name = userAuthModel.Name,
                RegistrationDate = DateTime.Now
            });

            userAuthModel.UserId = user.Id;

            await _authServices.Create(userAuthModel);
        }
        [HttpGet]
        [Route(RouteConstants.GetByToken)]
        public async Task<UserDto> GetUserByToken()
        {
            int userId = JwtToken.GetUserIdFromToken(Request.Headers);
            return await _userServices.Get(userId);
        }
    }
}

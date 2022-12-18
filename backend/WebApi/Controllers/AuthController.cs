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
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        [HttpPost]
        [Route(RouteConstants.SingIn)]
        public async Task<string> AuthorizeUser(UserAuthModelDto userAuthModel)
        {
            var user = await _authServices.ValidateUser("Izaiah3988@hotmail.com", "Izaiah39");
            List<Claim> claims = new() { new Claim(AuthConstants.ClaimType, user.Id.ToString()) };//???
            var token = JwtToken.GetToken(claims);
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedToken;
        }
    }
}

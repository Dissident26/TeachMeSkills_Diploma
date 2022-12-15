using Microsoft.AspNetCore.Mvc;
using Authentication.Helpers;

using Services.Dtos;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Authentication.Constants;

namespace JoRoomWebApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthServices _userAuthServices;
        public LoginController(IAuthServices userAuthServices)
        {
            _userAuthServices = userAuthServices;
        }
        //public IActionResult Index()
        //{

        //    return View();
        //}

        //[HttpPost]
        public async Task<JsonResult> Index(UserAuthModelDto userAuthModel)
        {
            
            // how to make queries from here?
            // user #3 //Kristina3879@gmail.com // Kristina38

            var user = await _userAuthServices.ValidateUser("Kristina3879@gmail.com", "Kristina38");
            List<Claim> claims = new() { new Claim(AuthConstants.ClaimType, user.Id.ToString()) };
            var token = JwtToken.GetToken(claims);
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            var response = new
            {   //миша всё хуйня, давай по новой
                // jwt в мвц это хуйня
                Token = encodedToken,
                User = user
            };

            return Json(response);
        }
    }
}

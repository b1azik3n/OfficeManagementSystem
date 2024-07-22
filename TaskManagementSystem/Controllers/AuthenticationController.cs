using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystem.Services.Authentication;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IConfiguration configuration;
        private readonly IAuthService service;

        public AuthenticationController(IHttpContextAccessor contextAccessor, IConfiguration configuration,IAuthService service) : base(contextAccessor)
        {
            this.configuration = configuration;
            this.service = service;
        }
    
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginRequest userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
                var response = new
                {
                    message = "Login successful",
                    token = token
                };

                return Ok(response);
            }
            return NotFound("User not found");

        }


        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {

                new Claim (ClaimTypes.Email, user. Email),
                new Claim (ClaimTypes.Role, user.UserType.ToString()),
                new Claim (ClaimTypes. NameIdentifier, user.Id.ToString()),


            };
            var token = new JwtSecurityToken(
                 configuration["Jwt: Issuer"],
                 configuration["Jwt: Audience"],
                  claims,
                  expires: DateTime.Now.AddDays(30),
                   signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private User Authenticate(UserLoginRequest userLogin)
        {
            var user = service.FindUser(userLogin);
            return user;


        }
        [HttpPost]

        public IActionResult RegisterUser(UserRequest user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (service.CheckIfDuplicateEmail<User, UserRequest>(user))
            {
                return BadRequest("EmailAlreadyExists!");
            }
            if (service.CheckIfDuplicatePhoneNumber<User, UserRequest>(user))
            {
                return BadRequest("PhoneNumberAlreadyExists!");
            }

            service.RegisterUser(user,GetUserId());
            return Ok();


        }


    }
}







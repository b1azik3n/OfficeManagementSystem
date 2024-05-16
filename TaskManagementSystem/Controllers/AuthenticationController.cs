using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystem.Services.Authentication;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IAuthService authenticationService;

        public AuthenticationController(IConfiguration configuration, IAuthService authenticationService)
        {
            this.configuration = configuration;
            this.authenticationService = authenticationService;
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
                new Claim (ClaimTypes.Role, user.UserType),
                new Claim (ClaimTypes. NameIdentifier, user.Id.ToString()),


            };
            var token = new JwtSecurityToken(
                 configuration["Jwt: Issuer"],
                 configuration["Jwt: Audience"],
                  claims,
                  expires: DateTime.Now.AddMinutes(15),
                   signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private User Authenticate(UserLoginRequest userLogin)
        {
            var user = authenticationService.FindUser(userLogin);
            return user;


        }
        [HttpPost]

        public IActionResult RegisterUser(RegisterUserRequest user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (authenticationService.RegisterUser(user) == true)
            {
                return Ok("Registration Successful");
            }
            return BadRequest("Something went wrong"); //better


        }


    }
}







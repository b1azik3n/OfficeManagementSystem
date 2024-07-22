using DomainLayer.Enum;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels
{
    public class UserRequest
    {

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public UserType UserType { get; set; }
        [Required]
        public string OrgID { get; set; }
    }
    public class UserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserType UserType { get; set; }
        public string OrgID { get; set; }

    }
    public class UserLoginRequest
    {
        [Required]

        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
    }
}

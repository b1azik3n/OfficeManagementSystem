using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels
{
    public class UserLoginRequest
    {
        [Required]

        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
    }
}

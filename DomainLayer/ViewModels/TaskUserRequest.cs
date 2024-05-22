using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels
{
    public class TaskUserRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]

        public Guid TaskId { get; set; }





    }
}

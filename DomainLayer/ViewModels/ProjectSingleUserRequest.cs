using DomainLayer.Model;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels
{
    public class ProjectSingleUserRequest
    {
        [Required]
        public Guid ProjectId { get; set; }
        [Required]

        public Guid UserId { get; set; }
        [Required]
        public Guid DesignationId { get; set; }

    }
}

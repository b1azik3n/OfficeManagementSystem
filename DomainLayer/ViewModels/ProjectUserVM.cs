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
    public class ProjectUserResponse
    {
        public string? UserName { get; set; }
        public string? DesignationName { get; set; }

    }
    public class ProjectMultipleUserRequest
    {

        [Required]
        public Guid ProjectId { get; set; }
        [Required]

        public List<UserAndDesigRequest> UserAndDesignation { get; set; }

    }
    public class ProjectUserMultipleResponse
    {
        [StringLength(100)]

        [Required]
        public string ProjectName { get; set; }

        public List<ProjectUserResponse> UserDesignation { get; set; }

    }
}

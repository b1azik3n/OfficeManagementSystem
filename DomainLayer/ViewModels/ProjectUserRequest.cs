using DomainLayer.Model;

namespace DomainLayer.ViewModels
{
    public class ProjectUserRequest
    {
        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }
        public Guid DesignationId { get; set; }

    }
}

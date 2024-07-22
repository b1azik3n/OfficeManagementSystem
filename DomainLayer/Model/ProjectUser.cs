using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DomainLayer.Model
{
    public class ProjectUser:BaseDetailed
    {

        [ForeignKey(nameof(Project))]
        
        public Guid ProjectId {  get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Designation))]

        public Guid  DesignationId { get; set; }
        public Designation Designation { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }


    }
}

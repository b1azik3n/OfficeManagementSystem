using DomainLayer.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Model
{
    public class TaskModel:BaseDetailed
    {

        public string Name { get; set; }
        public TaskType Type { get; set; }
        public Enum.TaskStatus Status { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; } 
        public Project Project { get; set; }

        public List<TaskUser> TaskUser { get; set; }


    }
}

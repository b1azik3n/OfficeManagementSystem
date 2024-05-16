using DomainLayer.Enum;

namespace DomainLayer.ViewModels
{
    public class TaskResponse
    {
        public string Name { get; set; }
        public TaskType Type { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public string Expected_Completion { get; set; } 
        public ProjectUserResponse AssignedTo { get; set; }
    }
}

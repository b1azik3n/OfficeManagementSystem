using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class TaskRequest
    {
        [Required]

        public string Name { get; set; }
        [Required]
        public TaskType Type { get; set; }
        [Required]

        public Enum.TaskStatus Status { get; set; }
        [Required]

        public string Description { get; set; }


        [Required]

        public Guid ProjectId { get; set; }

    }
    public class TaskResponse
    {
        public string Name { get; set; }
        public TaskType Type { get; set; }
        public Enum.TaskStatus Status { get; set; }
        public string Description { get; set; }
        public string Expected_Completion { get; set; }
        public ProjectUserResponse AssignedTo { get; set; }
    }
    public class TaskAllResponse
    {
        public string Name { get; set; }
        public Enum.TaskStatus Status { get; set; }
    }
    public class TaskStatusRequest
    {
        [Required]

        public Enum.TaskStatus Status { get; set; }
    }
    public class TaskStatusResponse
    {
        public Enum.TaskStatus Status { get; set; }
        public string Name { get; set; }
    }
    public class TaskUserRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]

        public Guid TaskId { get; set; }

    }
    public class DeleteTaskAssignedRequest
    {
        [Required]

        public Guid TaskId { get; set; }
        [Required]

        public Guid UserId { get; set; }
    }
}

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

}


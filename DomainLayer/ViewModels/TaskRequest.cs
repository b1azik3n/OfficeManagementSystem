using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class TaskRequest
    {
        
            public string Name { get; set; }
            public TaskType Type { get; set; }
            public Status Status { get; set; }
            public string Description { get; set; }
            public string Expected_Completion { get; set; }
            public Guid ProjectId { get; set; }
        
    }

}


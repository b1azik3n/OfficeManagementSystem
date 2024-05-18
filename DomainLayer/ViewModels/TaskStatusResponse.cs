using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class TaskStatusResponse
    {
        public Enum.TaskStatus Status { get; set; }
        public string Name { get; set; }
    }
}

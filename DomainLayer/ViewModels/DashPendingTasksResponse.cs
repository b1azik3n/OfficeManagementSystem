using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class DashPendingTasksResponse
    {
        public string TaskName { get; set; }
        public string ProjectName { get; set; }
        public TaskStatus Status { get; set; }
        public int Total { get; set; }
    }
}

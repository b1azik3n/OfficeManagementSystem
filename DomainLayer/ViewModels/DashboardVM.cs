using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class DashCompletedProjectsResponse
    {
        public string Project {  get; set; }
        public string ClientName {  get; set; }
        
    }
    public class DashCompletedTasksResponse
    {
        public string TaskName { get; set; }
        public string ProjectName { get; set; }

    }
    public class DashCurrentProjectsResponse
    {

        public string Project { get; set; }
        public string ClientName { get; set; }
        public TaskStatus Status { get; set; }
        public int Total { get; set; }
    }
    public class DashPendingTasksResponse
    {
        public string TaskName { get; set; }
        public string ProjectName { get; set; }
        public TaskStatus Status { get; set; }
        public int Total { get; set; }
    }
}

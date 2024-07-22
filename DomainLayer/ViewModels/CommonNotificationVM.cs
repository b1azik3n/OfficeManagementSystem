using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class CommonNotification
    {
        public string UserName { get; set; }
        public string ProjectName { get; set; }
        public string Designation {  get; set; }
        public string TaskName { get; set; }
        public string TaskStatusName { get; set; }
        public string EmailAddress { get; set; }
        public string ProjectLeadName { get; set; }
        public string ProjectLeadEmail { get; set;}
    }
}

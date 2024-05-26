using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class DashCurrentProjectsResponse
    {

        public string Project { get; set; }
        public string ClientName { get; set; }
        public TaskStatus Status { get; set; }
        public int Total {  get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class AllUsersSummaryResponse
    {
        public string UserName { get; set; }    
        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }
        public int CompletedProjects { get; set; }
        public int PendingProjects { get; set; }
    }
}

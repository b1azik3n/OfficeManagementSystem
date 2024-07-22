using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class ProjectClient: BaseDetailed
    {
        public Guid ProjectId { get; set; } 
        public Guid ClientId { get; set; }

        //public Client Client { get; set; }
        //public Project Project { get; set; }

    }
}

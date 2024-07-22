using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class IncidentRequest
    {
        public string Description { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProjectId { get; set; }
        public string Priority { get; set; }
        public string ReportedBy { get; set; }
        public string ContactNumber { get; set; }

    }
}

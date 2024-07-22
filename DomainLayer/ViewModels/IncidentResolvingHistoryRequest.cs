using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class IncidentResolvingHistoryRequest
    {
        public Guid IncidentId { get; set; }
        public string AttemptMethod { get; set; }
        public string ApproximateTime { get; set; }
    }
}

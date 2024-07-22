using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class IncidentTracking:BaseGuid
    {
        public Guid IncidentId { get; set; }
        public int AttemptNumber { get; set; }  
        public bool Succeeded { get; set; }
    }
}

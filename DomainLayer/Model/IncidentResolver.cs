using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class IncidentResolver:BaseGuid
    {
        [ForeignKey(nameof(Incident))]
        public Guid IncidentId { get; set; }
        [ForeignKey(nameof(Resolver))]
        public Guid ResolverId { get; set; }
        public DateTime AssignedOn { get; set; }= DateTime.Now;
        public IncidentStatus Status { get; set; }

       public Resolver Resolver { get; set; }
       public Incident Incident { get; set; }
    }
}

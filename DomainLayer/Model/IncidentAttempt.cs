using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class IncidentAttempt:BaseInt
    { 

    
        public int Attempt_Number { get; set; } =0;
        [ForeignKey(nameof(Incident))]
        public Guid IncidentId { get; set; }
        [ForeignKey(nameof(Resolver))]
        public Guid AttemptedBy { get; set; }
        public string AttemptMethod { get; set; }
        public string ApproximateTime { get; set; }

        public Incident Incident { get; set; }
        public Resolver Resolver { get; set; }


    }
}

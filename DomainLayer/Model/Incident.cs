using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Incident: BaseGuid
    {
        public string Description { get; set; }
        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }
        public Guid ProjectId { get; set; }
        public string Priority { get; set; }
        public string ReportedBy {  get; set; }
        public DateTime ReportedOn { get; set; }= DateTime.Now;
        public string ContactNumber { get; set; }   
        public bool IsSolved { get; set; }= false;
        public IncidentResolver IncidentResolver { get; set; }
        public Client Client { get; set; }  
        

    }
}

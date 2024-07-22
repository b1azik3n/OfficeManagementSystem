using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public  class AdminTransferIncidentRequest
    {
        public Guid IncidentId { get; set; }
        public Guid ResolverId { get; set; }    
        
    }
}

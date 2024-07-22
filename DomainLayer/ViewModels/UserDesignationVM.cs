using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class UserAndDesigRequest
    {
        public Guid UserId { get; set; }
        public Guid DesignationId { get; set; }
    }
}

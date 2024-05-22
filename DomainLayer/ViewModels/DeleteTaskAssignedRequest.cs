using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class DeleteTaskAssignedRequest
    {
        [Required]
        
        public Guid TaskId { get; set; }
        [Required]

        public Guid UserId { get; set; }
    }
}

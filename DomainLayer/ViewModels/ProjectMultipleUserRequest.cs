using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class ProjectMultipleUserRequest
    {

        [Required]
        public Guid ProjectId { get; set; }
        [Required]

        public List<UserAndDesigRequest> UserAndDesignation { get; set; }
        
    }
}

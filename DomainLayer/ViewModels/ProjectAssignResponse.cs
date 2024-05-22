using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class ProjectAssignResponse
    {
        [StringLength(100)]
        
        [Required]
        public string ProjectName { get; set; }

        public List<ProjectUserResponse> UserDesignation { get; set; }

    }
}

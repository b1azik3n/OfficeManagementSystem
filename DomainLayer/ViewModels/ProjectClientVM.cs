using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class ProjectClientRequest
    {
        [Required]

        public Guid ProjectId { get; set; }
        [Required]

        public Guid ClientId { get; set; }
    }
    public class ProjectClientResponse
    {

        public string ProjectName { get; set; }
        public string ClientName { get; set; }

    }
}

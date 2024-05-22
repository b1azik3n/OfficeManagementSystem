using DomainLayer.Enum;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels
{
    public class ProjectRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]

        public string Description { get; set; }
        [Required]

        public string StartDate { get; set; }

      
        public string ?EndDate { get; set; }
        [Required]
        public Enum.TaskStatus Status { get; set; }
        [Required]

        public Guid ClientId { get; set; }
        [Required]
        public Guid TeamLeadId{  get; set; }
        




    }
}

using DomainLayer.Enum;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Model
{
    public class Project:BaseDetailed
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get;set; }
        public Enum.TaskStatus Status { get; set; }

        [ForeignKey(nameof(Client))]

        public Guid ClientId { get; set; }
        [Required]
        public Guid TeamLeadId{  get; set; }




        //Navigation Property
        public Client Client { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
        public ICollection<TaskModel> Task { get; set; }
            

    }

}

using DomainLayer.Enum;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels
{
    public class EmployeeRequest
    {
        [Required]
        [StringLength(50)]

        public string Name { get; set; }
        [Required]

        public string JoinedDate { get; set; }
        [Required]

        public Position Position { get; set; }
        [Required]

        public EmployeeStatus Status { get; set; }
        [Required]

        public string LeftDate { get; set; }
        [Required]

        public string DOB { get; set; }
        [Required]

        public Gender Gender { get; set; }
        [EmailAddress]
        [Required]
        public string Email{ get; set; }
        [Required]
        

        public string PhoneNumber { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class ClientRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]

        public string Location { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        [Required]

        public int VAT { get; set; }
        [Required]

        public int PAN { get; set; }
    }
}

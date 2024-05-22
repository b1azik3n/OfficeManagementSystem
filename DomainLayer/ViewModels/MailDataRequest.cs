using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class MailDataRequest
    {
        [Required]
        [EmailAddress]
        public string EmailToId { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailToName { get; set; }
        [Required]
        [StringLength(200)]
        public string EmailSubject { get; set; }
        [Required]

        public string EmailBody { get; set; }
    }
}

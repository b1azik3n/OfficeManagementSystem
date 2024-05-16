using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Client:BaseNameClass
    {
        [Required]
        [StringLength(25)]
        public string Location { get; set; }
        public string PhoneNumber {  get; set; }

        public string EmailAddress { get; set; }    
        public int  VAT {  get; set; }
        public int PAN { get; set; }
 

        //Client < Project
        public ICollection<Project> Projects { get; set; }

    }
}

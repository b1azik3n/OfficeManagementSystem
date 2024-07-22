using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class ResolverRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Level Level { get; set; }
    }
    public class ResolverResponse
    {
        public string Name { get; set; }
        public Level Level { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class BaseGuid
    {

        [Key]
        [Column(Order = 0)]

        public Guid Id { get; set; }
    }
}

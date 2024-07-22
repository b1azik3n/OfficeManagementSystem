using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public abstract class BaseDetailed :BaseGuid
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn{ get; set; }= DateTime.Now;
        public Guid ? LastModifiedBy { get; set; }
        public DateTime ?LastModifiedOn { get; set;} = DateTime.Now;
    }
}

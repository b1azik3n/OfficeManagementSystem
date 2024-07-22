using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Resolver: BaseDetailed
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public Level Level { get; set; }
        public int ActiveCases { get; set; } = 0;
        public User User { get; set; }
    }
}

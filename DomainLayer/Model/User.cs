using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class User: BaseActor
    {
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string OrgID { get; set; }
        
        public ICollection<DailyLog> DailyLogs { get; set; }



    }
}

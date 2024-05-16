using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class TaskAllResponse
    {
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}

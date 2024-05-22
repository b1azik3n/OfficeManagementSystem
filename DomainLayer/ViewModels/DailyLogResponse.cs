using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class DailyLogResponse
    {
        public string UserName {  get; set; }

        public string TaskTitle { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class TaskUser:BaseClass
    {
        [ForeignKey(nameof(User))]
        public Guid UserId{  get; set; }
        [ForeignKey(nameof(Task))]
        public Guid TaskId { get; set; }
        public TaskModel Task { get; set; }
        public User User { get; set; }




    }
}

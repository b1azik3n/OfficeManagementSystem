using DomainLayer.Enum;
using Microsoft.VisualBasic;

namespace DomainLayer.ViewModels
{
    public class ProjectRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Status Status { get; set; }

        public Guid ClientId { get; set; } 





    }
}

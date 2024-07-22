using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels
{
    public class DailyLogRequest
    {
        [Required]

        public string TaskTitle { get; set; }
        [Required]

        [StringLength(500)]
        public string Description { get; set; }
    }
    public class DailyLogResponse
    {
        public string UserName { get; set; }

        public string TaskTitle { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
    }
}

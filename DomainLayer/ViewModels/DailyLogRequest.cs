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
}

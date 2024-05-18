using DomainLayer.Enum;

namespace DomainLayer.ViewModels
{
    public class EmployeeRequest
    {

        public string Name { get; set; }
        public string JoinedDate { get; set; }
        public Position Position { get; set; }
        public EmployeeStatus Status { get; set; }
        public string LeftDate { get; set; }
        public string DOB { get; set; }
        public Gender Gender { get; set; }
        public string EmailAddress { get; set; }
    }
}

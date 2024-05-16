namespace DomainLayer.ViewModels
{
    public class TaskUserRequest
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }


        public string Assigned_On { get; set; }


    }
}

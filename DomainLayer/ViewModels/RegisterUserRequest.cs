namespace DomainLayer.ViewModels
{
    public class RegisterUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
        public string OrgID { get; set; }


    }
}

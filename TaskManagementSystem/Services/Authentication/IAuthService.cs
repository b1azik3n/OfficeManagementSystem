using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.Authentication
{
    public interface IAuthService
    {
        User FindUser(UserLoginRequest user);
        bool RegisterUser(RegisterUserRequest user);
    }
}

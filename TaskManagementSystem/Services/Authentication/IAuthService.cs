using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Authentication
{
    public interface IAuthService: IService
    {
        User FindUser(UserLoginRequest user);
        bool RegisterUser(UserRequest user);
    }
}

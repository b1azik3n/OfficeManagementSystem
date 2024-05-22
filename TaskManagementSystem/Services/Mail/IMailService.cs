using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Mail
{
    public interface IMailService:IService
    {
        bool SendMail(MailDataRequest mailDataRequest);
    }
}

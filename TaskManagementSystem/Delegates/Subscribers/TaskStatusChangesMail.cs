using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.Extensions.Options;
using TaskManagementSystem.MailConfigurations;
using TaskManagementSystem.Services.Mail;

namespace TaskManagementSystem.Delegates.Subscribers
{
    public class TaskStatusChangesMail : MailService
    {
        public TaskStatusChangesMail(IOptions<MailSettings> mailSettingsOptions, IMapper mapper, IUnitOfWork unit) : base(mailSettingsOptions, mapper, unit)
        {
        }
        public void OnCriticalChanges(object source, AdditionalEventArgs args)
        {
            NotifyTaskStatusChanges(args._commonNotification);
        }

        public void NotifyTaskStatusChanges(CommonNotification response)
        {

            var maildata = new MailDataRequest
            {
                EmailBody = $"Hello {response.UserName}! " +
                        $"TaskName: {response.TaskName} " + $"Status: {response.TaskStatusName}",
                EmailSubject = "TaskStatusUpdate",
                EmailToId = $"{response.EmailAddress}",
                EmailToName = $"{response.UserName}",

            };
            SendMail(maildata);
        }
    }
}

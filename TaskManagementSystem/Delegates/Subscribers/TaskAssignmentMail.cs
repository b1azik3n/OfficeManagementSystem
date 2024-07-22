using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.Extensions.Options;
using TaskManagementSystem.MailConfigurations;
using TaskManagementSystem.Services.Mail;

namespace TaskManagementSystem.Delegates.Subscribers
{
    public class TaskAssignmentMail:MailService
    {
        public TaskAssignmentMail(IOptions<MailSettings> mailSettingsOptions, IMapper mapper, IUnitOfWork unit) : base(mailSettingsOptions, mapper, unit)
        {
        }

        public void OnCriticalChanges(object source, AdditionalEventArgs args)
        {
            NotifyTaskAssignment(args._commonNotification);


        }
        public void NotifyTaskAssignment(CommonNotification common)
        {
            var maildata = new MailDataRequest
            {
                EmailBody = $"Hello {common.UserName}! " +
                        $"You're assigned to Task: {common.TaskName} ",
                EmailSubject = "TaskAssignment",
                EmailToId = $"{common.EmailAddress}",
                EmailToName = $"{common.UserName}",

            };
            SendMail(maildata);

        }
    }
}

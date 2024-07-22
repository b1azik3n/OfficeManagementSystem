using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.ViewModels;
using Microsoft.Extensions.Options;
using TaskManagementSystem.MailConfigurations;
using TaskManagementSystem.Services.Mail;

namespace TaskManagementSystem.Delegates.Subscribers
{
    public class ProjectAssignmentMail : MailService
    {

        public ProjectAssignmentMail(IOptions<MailSettings> mailSettingsOptions, IMapper mapper, IUnitOfWork unit) : base(mailSettingsOptions, mapper, unit)
        {
        }


        public void OnCriticalChanges(object source, AdditionalEventArgs args)
        {
            NotifyProjectAssignment(args._commonNotification);

        }
        public void NotifyProjectAssignment(CommonNotification request)
        {
                    var maildata = new MailDataRequest
                    {
                        EmailBody = $"Hello {request.UserName}! " +
                        $"You're assigned to Project {request.ProjectName} as {request.Designation}",
                        EmailSubject = "ProjectAssignment",
                        EmailToId = $"{request.EmailAddress}",
                        EmailToName = $"{request.UserName}",

                    };
                    SendMail(maildata); 

            
        }
    }
}

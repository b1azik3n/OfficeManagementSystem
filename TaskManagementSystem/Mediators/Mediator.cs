using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.Extensions.Options;
using TaskManagementSystem.Delegates.Publisher;
using TaskManagementSystem.Delegates.Subscribers;
using TaskManagementSystem.MailConfigurations;

namespace TaskManagementSystem.Mediators
{
    public class Mediator : Services.Mail.MailService, IMediator
    {
        private readonly IOptions<MailSettings> mailSettingsOptions;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public Mediator(IOptions<MailSettings> mailSettingsOptions, IMapper mapper, IUnitOfWork unit) : base(mailSettingsOptions, mapper, unit)
        {
            this.mailSettingsOptions = mailSettingsOptions;
            this.mapper = mapper;
            this.unit = unit;
        }

        //for Projectassignment

        public void Notify(ProjectMultipleUserRequest request)
        {
            //Initailizing Publishers and Subscribers

            var projectassign = new ProjectAssignmentMail(mailSettingsOptions,mapper,unit);
            var newAssignmentToLeadMail = new NewAssignmentToLeadMail(mailSettingsOptions,mapper,unit);
            var publishermail = new PublisherMail();
            //subscribing to publisher
            publishermail.CriticalChanges += newAssignmentToLeadMail.OnCriticalChanges;  //Lead
            publishermail.CriticalChanges += projectassign.OnCriticalChanges; //ProjectMember

            foreach (var Id in request.UserAndDesignation)
            {
                var user = GetByID<User, UserResponse>(Id.UserId);
                var project = GetByID<Project, ProjectResponse>(request.ProjectId);
                var designation = GetByID<Designation, DesignationRequest>(Id.DesignationId);
                var sendforNotification = new CommonNotification
                {
                    UserName = user.Name,
                    ProjectName = project.Name,
                    Designation = designation.Name,
                    EmailAddress=user.Email,
                    
                };
                
                publishermail.SendNotification(sendforNotification);

            }
        }
        //For TaskAssignment

        public void Notify(TaskUserRequest request)
        {

            var taskAssignmentMail= new TaskAssignmentMail(mailSettingsOptions, mapper, unit);
            var publishermail = new PublisherMail();

            publishermail.CriticalChanges += taskAssignmentMail.OnCriticalChanges;

            var user = GetByID<User, UserResponse>(request.UserId);
            var task = GetByID<TaskModel, TaskRequest>(request.TaskId);
            var sendforNotification = new CommonNotification
            {
                UserName = user.Name,
                TaskName= task.Name,
                EmailAddress=user.Email
            };
            publishermail.SendNotification(sendforNotification);
        }

        //For TaskStatusChanges
        public void Notify( Guid TaskId)
        {
            var taskStatusChangesMail = new TaskStatusChangesMail(mailSettingsOptions, mapper, unit);
            var publishermail = new PublisherMail();
            
            publishermail.CriticalChanges += taskStatusChangesMail.OnCriticalChanges;

            var task = GetByID<TaskModel, TaskRequest>(TaskId);
            var project = GetByID<Project, ProjectRequest>(task.ProjectId);
            var user = GetByID<User, UserResponse>(project.TeamLeadId);
            var sendforNotification = new CommonNotification
            {
                UserName = user.Name,
                TaskName = task.Name,
                EmailAddress = user.Email,
                TaskStatusName=task.Status.ToString(),
            };
            publishermail.SendNotification(sendforNotification);


        }

    }
}

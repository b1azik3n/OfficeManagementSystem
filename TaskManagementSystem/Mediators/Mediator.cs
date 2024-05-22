using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using MailKit;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using TaskManagementSystem.MailConfigurations;
using TaskManagementSystem.Services.GeneralService;
using TaskManagementSystem.Services.Mail;

namespace TaskManagementSystem.Mediators
{
    public class Mediator : Services.Mail.MailService, IMediator
    {
        public Mediator(IOptions<MailSettings> mailSettingsOptions, IMapper mapper, IUnitOfWork unit) : base(mailSettingsOptions, mapper, unit)
        {
        }

        public void NotifyProjectAssignment(ProjectMultipleUserRequest request)
        {
            foreach (var Id in request.UserAndDesignation)
            {
                var user = GetByID<User, UserRequest>(Id.UserId);
                var project = GetByID<Project, ProjectRequest>(request.ProjectId);
                var designation = GetByID<Designation, DesignationRequest>(Id.DesignationId);
                if (user != null)
                {
                    var maildata = new MailDataRequest
                    {
                        EmailBody = $"Hello {user.Name}! " +
                        $"You're assigned to Project {project.Name} as {designation.Name}",
                        EmailSubject = "ProjectAssignment",
                        EmailToId = $"{user.Email}",
                        EmailToName = $"{user.Name}",

                    };
                    SendMail(maildata);
                }

            }


        }

        public void NotifyTaskAssignment(TaskUserRequest taskUser)
        {
            var user=GetByID<User,UserRequest>(taskUser.UserId);
            var task = GetByID<TaskModel,TaskRequest>(taskUser.TaskId);
            var maildata = new MailDataRequest
            {
                EmailBody = $"Hello {user.Name}! " +
                        $"You're assigned to Task: {task.Name} ",
                EmailSubject = "TaskAssignment",
                EmailToId = $"{user.Email}",
                EmailToName = $"{user.Name}",

            };
            SendMail(maildata);

        }

        public void NotifyTaskStatusChanges(TaskStatusResponse response, Guid TaskId)
        {
            var task=GetByID<TaskModel,TaskRequest>(TaskId);
            var project= GetByID<Project, ProjectRequest>(task.ProjectId);
            var user= GetByID<User,UserRequest>(project.TeamLeadId);
            var maildata = new MailDataRequest
            {
                EmailBody = $"Hello {user.Name}! " +
                        $"TaskName: {task.Name} "+$"Status: {task.Status.ToString()}" ,
                EmailSubject = "TaskStatusUpdate",
                EmailToId = $"{user.Email}",
                EmailToName = $"{user.Name}",

            };
            SendMail(maildata);


        }
    }
}

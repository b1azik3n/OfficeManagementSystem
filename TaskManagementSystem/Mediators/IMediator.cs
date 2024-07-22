using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;
using TaskManagementSystem.Services.Mail;

namespace TaskManagementSystem.Mediators
{
    public interface IMediator : IMailService
    {
        //void NotifyProjectAssignment(ProjectMultipleUserRequest request);
        //void NotifyTaskAssignment(TaskUserRequest taskUser);
        //void NotifyTaskStatusChanges(TaskStatusResponse response, Guid TaskId);
         void Notify(ProjectMultipleUserRequest request);
         void Notify(Guid TaskId);
        void Notify(TaskUserRequest request);




    }
}

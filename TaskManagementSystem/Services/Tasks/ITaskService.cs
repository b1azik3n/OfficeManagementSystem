using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Tasks
{
    public interface ITaskService: IService
    {
         bool AssignTask(TaskUserRequest taskProjectVM,Guid Id);


        void CreateTask(TaskRequest taskVM);
        public TaskResponse GetByID(Guid Id);

    }
}

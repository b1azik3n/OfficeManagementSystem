using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Tasks
{
    public class TaskService : Service, ITaskService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public TaskService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public bool AssignTask(TaskUserRequest taskUser,Guid Id)
        {
   
            if (unit.TaskRepo.CheckAssignment(taskUser))
            {
                AddNew<TaskUser, TaskUserRequest>(taskUser, Id);
                return true;
                

            }
            return false;

        }

        public void CreateTask(TaskRequest taskProjectVM)
        {
            var send= mapper.Map<TaskModel>(taskProjectVM);
            unit.TaskRepo.AddTask(send);
           
            
            unit.SaveChanges();
            
            
        }
        public  TaskResponse GetByID(Guid Id)
        {
            var send = unit.TaskRepo.GetByID(Id);
                 
                return send;                        
        }
        public void DeleteTaskAssignment(DeleteTaskAssignedRequest vm)
        {
            unit.TaskRepo.RemoveTaskAssignment(vm);
        }


    }
}

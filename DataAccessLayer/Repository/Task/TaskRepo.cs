using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.General;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.Repository.Task
{
    public class TaskRepo : Repo, ITaskRepo
    {
        private readonly TaskDbContext context;
        private readonly IMapper mapper;

        public TaskRepo(TaskDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public bool CheckAssignment(TaskUserRequest task)
        {
            var taskcontent = context.Tasks.FirstOrDefault(c => c.Id == task.TaskId);
            Guid projectid = context.Tasks.Include(x=>x.Project).Where(x=> x.Id == task.TaskId).
                Select(x=> x.ProjectId).
                FirstOrDefault();

            List<Guid> userids = context.ProjectUsers.Where(x => x.ProjectId == projectid).Select(x => x.UserId).ToList();
            foreach (var user in userids)
            {
                if(user==task.UserId)
                {
                   return true;
                }
            }
                return false;
            



        }
        public void AddTask(TaskModel task)
        {
            context.Tasks.Add(task);
        }
        public TaskResponse GetByID(Guid TaskId)
        {
            var response = context.Tasks
                .Include(x => x.TaskUser)
                   .ThenInclude(x => x.User).


                //TaskResponse task = context.TaskUser.
                //    Include(x => x.Task).
                //    ThenInclude(x => x.Project).
                //      ThenInclude(x => x.ProjectUsers).
                //       ThenInclude(x => x.User).
                
                Where(x => x.Id == TaskId).
                Select(task => new TaskResponse
                {
                    Name = task.Name,
                    Description = task.Description,
                    Type = task.Type,
                    Status = task.Status,
                    Expected_Completion = task.Expected_Completion,
                    AssignedTo = task.Project.ProjectUsers.Select(o => new ProjectUserResponse
                    {
                        UserName = o.User.Name,
                        DesignationName=o.Designation.Name //TaskNotAssignedthen accordingly make..
                    }).First()
                   
                        
                    
                }).
                FirstOrDefault();
            return response;
            //return task;
            //x.Project.ProjectUsers.

            //        Select(member => x.Id==TaskId? new ProjectUserResponse
            //        {
            //            UserName = member.User.Name,
            //            DesignationName = member.Designation.Name,

            //        }: new ProjectUserResponse
            //        {
            //            UserName="NotAssigned",
            //            DesignationName="NotAssigned"
            
        }
    }
}

using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.General;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

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
        public void RemoveTaskAssignment(DeleteTaskAssignedRequest task) { 
            var check=context.TaskUsers.FirstOrDefault(x=> x.TaskId == task.TaskId && x.UserId==task.UserId);
            if (check != null)
            {
                context.TaskUsers.Remove(check);
            }

        }
        public TaskResponse GetByID(Guid TaskId)
        {
            //var taskQuery = context.Tasks.AsQueryable();
            //var userQuery= context.Users.AsQueryable();
            //var taskUserQuery =context.TaskUsers.AsQueryable();
            //var projectQuery= context.Projects.AsQueryable();
            //var projectuserQuery = context.ProjectUsers.AsQueryable();
            //var resultQuery = (from taskUser in taskUserQuery
            //                   join task in taskQuery on taskUser.TaskId equals task.Id into taskgGroup
            //                   from task in taskgGroup.DefaultIfEmpty()
            //                   join user in userQuery on taskUser.UserId equals user.Id into usergroup
            //                   from user in usergroup.DefaultIfEmpty()
            //                   join project in projectQuery on task.ProjectId equals project.Id into projectgroup
            //                   from project in projectgroup.DefaultIfEmpty()
            //                   join projectUser in projectuserQuery on project.Id equals projectUser.ProjectId into projectusergroup
            //                   from projectUser in projectusergroup.DefaultIfEmpty().AsEnumerable()

            //                   where task.Id == TaskId
            //                   select new TaskResponse
            //                   {
            //                       Name = task.Name,
            //                       Description = task.Description,
            //                       Type = task.Type,
            //                       Status = task.Status,
            //                       Expected_Completion = task.Expected_Completion,
            //                       AssignedTo = projectusergroup.Select(o => new ProjectUserResponse
            //                       {
            //                           UserName = o.User.Name,
            //                           DesignationName = o.Designation.Name //TaskNotAssignedthen accordingly make.. // run firsst in sql
            //                       }).FirstOrDefault()
            //                   }).FirstOrDefault();

            //return resultQuery;

            //var resultQuery = (from taskUser in taskUserQuery
            //                   join task in taskQuery on taskUser.TaskId equals task.Id into taskgGroup
            //                   from task in taskgGroup.DefaultIfEmpty()
            //                   join user in userQuery on taskUser.UserId equals user.Id into usergroup
            //                   from user in usergroup.DefaultIfEmpty()
            //                   where task.Id == TaskId
            //                   select new TaskResponse
            //                   {
            //                       Name = task.Name,
            //                       Description = task.Description,
            //                       Type = task.Type,
            //                       Status = task.Status,
            //                       Expected_Completion = task.Expected_Completion,
            //                       AssignedTo = task.Project.ProjectUsers.Select(o => new ProjectUserResponse
            //                       {
            //                           UserName = o.User.Name,
            //                           DesignationName = o.Designation.Name //TaskNotAssignedthen accordingly make..
            //                       }).FirstOrDefault()
            //                   }).FirstOrDefault();


            //TaskResponse task = context.TaskUsers.
            //    Include(x => x.Task).
            //    ThenInclude(x => x.Project).
            //      ThenInclude(x => x.ProjectUsers).
            //       ThenInclude(x => x.User).


            var response = context.Tasks
                .Include(x => x.TaskUser)
                   .ThenInclude(x => x.User).
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
                    DesignationName = o.Designation.Name //TaskNotAssignedthen accordingly make..
                }).First()



            }).
                FirstOrDefault();
            return response;
            
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

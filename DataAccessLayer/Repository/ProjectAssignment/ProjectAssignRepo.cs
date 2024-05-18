using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.General;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using System.Data;

namespace DataAccessLayer.Repository.AssignMember
{
    public class ProjectAssignRepo : Repo, IProjectAssignRepo
    {
        private readonly TaskDbContext context;
        private readonly IMapper mapper;

        public ProjectAssignRepo(TaskDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddMember(ProjectUserRequest member)
        {
            var model = mapper.Map<ProjectUser>(member);
            context.ProjectUsers.Add(model);

        }
        public ProjectAssignResponse GetAll(Guid id)
        {

            ProjectAssignResponse projectDetails = context.Projects
                //.Include(x => x.ProjectUsers)
                //    .ThenInclude(x => x.User)
                .Where(x => x.Id == id)
                .Select(project => new ProjectAssignResponse
                {
                    ProjectName = project.Name,
                    UserDesignation = project.ProjectUsers.Select(member => new ProjectUserResponse
                    {
                        UserName = member.User.Name,
                        DesignationName = member.Designation.Name
                    }).ToList(),
                })
                .First();

            return projectDetails;

            //List<ProjectUser> project = context.ProjectUser
            //    .Include(x => x.Project)
            //    .Include(x => x.User)
            //    .Where(x => x.ProjectId == id)
            //    .ToList();
            ////projectionn betterment tryy


            //List<ProjectUserResponse> mainlist = context.ProjectUser
            //    .Where(x => x.ProjectId == id)
            //    .Select(x => new ProjectUserResponse
            //    {
            //        ProjectName = x.Project.Name,
            //        UserName = x.User.Name,
            //        ProjectRole = x.Designation.Name
            //    })
            //    .ToList();
            //return mainlist;

            //foreach (var loop in project)
            //{
            //   var user= context.Users.FirstOrDefault(x => x.Id == loop.UserId);
            //   var projects = context.Projects.FirstOrDefault(x => x.Id == loop.Assigned_ProjectId);
            //   var role =context.ProjectRoles.FirstOrDefault(x => x.Id == loop.ProjectRoleId);
            //    ProjectNMembersDisplayVM data = new ProjectNMembersDisplayVM
            //    {
            //        ProjectName = projects.Name,
            //        UserName = user.Name,
            //        ProjectRole = role.Name
            //    };
            //    mainlist.Add(data);
            //}
            //return mainlist;


        }
    }
}

using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.General;
using DomainLayer.Enum;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace DataAccessLayer.Repository.Projects
{
    public class ProjectRepo : Repo,IProjectRepo
    {
        private readonly TaskDbContext context;
        private readonly IMapper mapper;

        public ProjectRepo(TaskDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddNew(Project project,Guid id)
        {
            project.Status = Status.Started;
            project.ClientId= id;
            context.Projects.Add(project);

        }

        public List<ProjectResponse> GetAllProjects()
        {
            var query = context.Projects;
            var map= mapper.ProjectTo<ProjectResponse>(query);
            var list=map.ToList();
            return list;
        }

        public ProjectResponse GetProjectByIdViewModel(Guid Id)
        {
            var project= context.Projects.FirstOrDefault(x => x.Id == Id);
            if (project == null)
            {
                return null;
            }
            var projectvm=mapper.Map<ProjectResponse>(project);
            projectvm.ClientName = context.Clients.FirstOrDefault(x => x.Id == project.ClientId).Name;
            return projectvm;
        }
        public Project GetProjectByIdMainModel(Guid Id)
        {
            var project = context.Projects.FirstOrDefault(x => x.Id == Id);
            if (project == null)
            {
                return null;
            }
            return project;
        }

            public void RemoveProject(Project project)
        {
            context.Projects.Remove(project);

        }

        public void UpdateProject(Project project)
        {
            context.Projects.Update(project);
        }
    }
}

using AutoMapper;
using DataAccessLayer.Repository.Projects;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Projects
{
    public class ProjectService :Service, IProjectService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public ProjectService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public void AddNew(ProjectRequest projectVM, Guid id)
        {
            var project = mapper.Map<Project>(projectVM);
            unit.ProjectRepo.AddNew(project, id);
            unit.SaveChanges();

        }

        public void EditProject(ProjectRequest projectVM, Guid Id)
        {
            var project = unit.ProjectRepo.GetProjectByIdMainModel(Id);
            mapper.Map(projectVM, project);
            unit.ProjectRepo.UpdateProject(project);
            unit.SaveChanges();

        }

        public List<ProjectResponse> GetAllProjects()
        {
            var list = unit.ProjectRepo.GetAllProjects();
            return list;

        }

        //public ProjectResponse GetProjectById(Guid Id)
        //{
        //    var project = unit.ProjectRepo.GetProjectByIdMainModel(Id);
        //    var vm = mapper.Map<ProjectResponse>(project);

        //    var name = unit.Repo.GetNameFromId<Client>(project.ClientId);
        //    vm.ClientName = name;
        //    return vm;
        //}
        public ProjectResponse GetByID(Guid Id)
        {
            var project = unit.LogRepo.GetByID<Project>(Id);
            var vm = mapper.Map<ProjectResponse>(project);
            var name = unit.Repo.GetNameFromId<Client>(project.ClientId);
            vm.ClientName = name;
            return vm;
        }

        public void RemoveProject(Guid Id)
        {
            unit.Repo.Remove<Project>(Id);
        }
    }
    
}

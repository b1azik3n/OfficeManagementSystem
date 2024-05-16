using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Projects
{
    public interface IProjectService:IService
    {
        void AddNew(ProjectRequest project, Guid id);
        List<ProjectResponse> GetAllProjects();
        //ProjectResponse GetProjectById(Guid Id);
        void EditProject(ProjectRequest projectVM, Guid Id);
        ProjectResponse GetByID(Guid Id);
        

    }
}

using DomainLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Model;
using DataAccessLayer.Repository.General;

namespace DataAccessLayer.Repository.Projects
{
    public interface IProjectRepo:IRepo
    {
        void AddNew(Project project, Guid id);
        //void Remove(Project project);
        List<ProjectResponse> GetAllProjects();
        ProjectResponse GetProjectByIdViewModel(Guid Id);
        Project GetProjectByIdMainModel(Guid Id);

            void UpdateProject (Project project);
    }
}

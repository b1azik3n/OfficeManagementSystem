using DataAccessLayer.Repository.General;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace DataAccessLayer.Repository.ProjectAssignment
{
    public interface IProjectAssignRepo : IRepo
    {
        void AddMember(ProjectSingleUserRequest member);
        ProjectUserMultipleResponse GetAll(Guid id);

    }
}

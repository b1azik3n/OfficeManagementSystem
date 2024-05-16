using DataAccessLayer.Repository.General;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace DataAccessLayer.Repository.AssignMember
{
    public interface IProjectAssignRepo:IRepo
    {
        void AddMember(ProjectUserRequest member);
        ProjectAssignResponse GetAll(Guid id);

    }
}

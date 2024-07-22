using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.ProjectAssign
{
    public interface IProjectAssignService : IService
    {
        //void AddMember(ProjectUserRequest member);
        ProjectUserMultipleResponse ViewMembers(Guid Id);
        void AddNew(ProjectMultipleUserRequest request, Guid Id);



    }
}

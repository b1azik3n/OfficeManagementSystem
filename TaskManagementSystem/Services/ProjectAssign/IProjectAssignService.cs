using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.MemberAssign
{
    public interface IProjectAssignService:IService
    {
        //void AddMember(ProjectUserRequest member);
         ProjectAssignResponse ViewMembers(Guid Id);
    }
}

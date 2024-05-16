using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.MemberAssign
{
    public class ProjectAssignService : Service,IProjectAssignService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public ProjectAssignService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }


        //public void AddMember(ProjectUserRequest project)
        //{
        //    var send = mapper.Map<ProjectUser>(project);
        //    unit.ProjectAssignRepo.AddMember(send);
        //    unit.SaveChanges();

        //}

        public ProjectAssignResponse ViewMembers(Guid Id)
        {
            var data = unit.ProjectAssignRepo.GetAll(Id);
            return data;

        }
    }
}

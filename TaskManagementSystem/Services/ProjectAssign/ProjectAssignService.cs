using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.ProjectAssign
{
    public class ProjectAssignService : Service, IProjectAssignService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public ProjectAssignService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

       


        public ProjectUserMultipleResponse ViewMembers(Guid Id)
        {
            var data = unit.ProjectAssignRepo.GetAll(Id);
            return data;

        }
        public void AddNew(ProjectMultipleUserRequest request, Guid Id)
        {
            foreach (var user in request.UserAndDesignation)
            {
                var singlerequest = new ProjectSingleUserRequest
                {
                    UserId = user.UserId,
                    ProjectId = request.ProjectId,
                    DesignationId = user.DesignationId,


                };
                AddNew<ProjectUser, ProjectSingleUserRequest>(singlerequest, Id);
            }
        }
    }
}


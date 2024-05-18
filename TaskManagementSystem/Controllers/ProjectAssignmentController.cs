using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.MemberAssign;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]

    public class ProjectAssignmentController : BaseController
    {
        private readonly IProjectAssignService service;

        public ProjectAssignmentController(IProjectAssignService service, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            this.service = service;
        }

        [HttpPost]

        public IActionResult AssignMember([FromBody] ProjectUserRequest projectMemberVM)
        {
            var id = GetUserId();   
            service.AddNew<ProjectUser, ProjectUserRequest>(projectMemberVM,id);
            return Ok("AddedMemberToProject");

        }
        [HttpGet]
        public IActionResult ViewProjectMembers(Guid ProjectId)
        {
            ProjectAssignResponse details =service.ViewMembers(ProjectId);
            return Ok(details);

        }
        [HttpPut]
        public IActionResult EditAssigment([FromBody] ProjectUserRequest task, Guid Id)
        {

            service.Edit<ProjectUser, ProjectUserRequest>(task, Id, GetUserId());
            var updated = service.GetByID<ProjectUser,ProjectUserResponse>(Id);
            return Ok(new { message = "Updated", updated });

        }
    }
}

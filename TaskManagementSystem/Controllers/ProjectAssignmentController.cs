using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.MemberAssign;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]

    public class ProjectAssignmentController : ControllerBase
    {
        private readonly IProjectAssignService service;

        public ProjectAssignmentController(IProjectAssignService service)
        {
            this.service = service;
        }

        [HttpPost]

        public IActionResult AssignMember([FromBody] ProjectUserRequest projectMemberVM)
        {
            service.AddNew<ProjectUser,ProjectUserRequest>(projectMemberVM);
            return Ok("AddedMemberToProject");

        }
        [HttpGet]
        public IActionResult ViewProjectMembers(Guid ProjectId)
        {
            ProjectAssignResponse details =service.ViewMembers(ProjectId);
            return Ok(details);

        }
    }
}

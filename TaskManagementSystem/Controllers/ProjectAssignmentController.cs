using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Mediators;
using TaskManagementSystem.Services.ProjectAssign;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]

    public class ProjectAssignmentController : BaseController
    {
        private readonly IProjectAssignService service;
        private readonly IMediator mediator;

        public ProjectAssignmentController(IProjectAssignService service, IHttpContextAccessor contextAccessor,IMediator mediator) : base(contextAccessor)
        {
            this.service = service;
            this.mediator = mediator;
        }

        [HttpPost]

        public IActionResult AssignMember([FromBody] ProjectMultipleUserRequest projectMemberVM)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }
            var id = GetUserId();
            service.AddNew(projectMemberVM, id);
            mediator.Notify(projectMemberVM);

            return Ok("AddedMemberToProject");

        }
        [HttpGet]
        public IActionResult ViewProjectMembers(Guid ProjectId)
        {
            if(service.CheckIfIdExists<Project>(ProjectId))
            {

                ProjectUserMultipleResponse details = service.ViewMembers(ProjectId);
                return Ok(details);
            }
            return BadRequest();

        }
        [HttpPut]
        public IActionResult EditAssigment([FromBody] ProjectSingleUserRequest task, Guid Id)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }
            service.Edit<ProjectUser, ProjectSingleUserRequest>(task, Id, GetUserId());
            var updated = service.GetByID<ProjectUser,ProjectUserResponse>(Id);
            return Ok(new { message = "Updated", updated });

        }
        [HttpDelete]



        public IActionResult DeleteAssignment(Guid Id)
        {
            if (service.Remove<ProjectUser, ProjectSingleUserRequest>(Id))
            {
                return Ok("Deleted");


            }
            return NotFound("User Doesn't Exist");

        }
    }
}

using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Mediators;
using TaskManagementSystem.Services.Tasks;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : BaseController
    {
        private readonly ITaskService service;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IMediator mediator;

        public TaskAssignmentController(ITaskService service, IHttpContextAccessor contextAccessor, IMediator mediator) : base(contextAccessor)
        {
            this.service = service;
            this.contextAccessor = contextAccessor;
            this.mediator = mediator;
        }

        [HttpPost]
        public IActionResult AssignTask([FromBody] TaskUserRequest taskUser)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }
            var id=GetUserId();
            if (service.AssignTask(taskUser,id))
            {
                mediator.Notify(taskUser);   
                return Ok("task Assigned"); //kasle k ma kk you can do..
            }
            return BadRequest("MemberNotAssignedToProjectItSeems");
        }
        [HttpPut]
        [Route("[Action]")]
        public IActionResult EditTaskStatus([FromBody] TaskStatusRequest taskStatus,Guid TaskID)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }

            service.Edit<TaskModel, TaskStatusRequest>(taskStatus,TaskID,GetUserId());
            var updated = service.GetByID<TaskModel,TaskStatusResponse>(TaskID);
            mediator.Notify(TaskID);

            return Ok(new { updateddata = updated });
        }
        [HttpDelete]
        public IActionResult DeleteAssignment([FromBody] DeleteTaskAssignedRequest request)
        {
            service.DeleteTaskAssignment(request);
            return Ok();    
        }

        

    }
}

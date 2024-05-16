using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using TaskManagementSystem.Services.Tasks;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly ITaskService service;

        public TaskAssignmentController(ITaskService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AssignTask([FromBody] TaskUserRequest taskUser)
        {
            if (service.AssignTask(taskUser))
            {
                return Ok("task Assigned"); //kasle k ma kk you can do..
            }
            return BadRequest("MemberNotAssignedToProjectItSeems");
        }
        [HttpPut]
        [Route("[Action]")]
        public IActionResult EditStatus([FromBody] TaskStatusRequest taskStatus,Guid TaskID)
        {

            service.Edit<TaskModel, TaskStatusRequest>(taskStatus,TaskID);
            var updated = service.GetByID<TaskModel,TaskStatusResponse>(TaskID);
            return Ok(new { updateddata = updated });
        }
    }
}

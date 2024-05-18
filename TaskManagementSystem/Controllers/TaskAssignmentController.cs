using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Security.Claims;
using TaskManagementSystem.Services.Tasks;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : BaseController
    {
        private readonly ITaskService service;
        private readonly IHttpContextAccessor contextAccessor;

        public TaskAssignmentController(ITaskService service, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            this.service = service;
            this.contextAccessor = contextAccessor;
        }

        [HttpPost]
        public IActionResult AssignTask([FromBody] TaskUserRequest taskUser)
        {
            var id=GetUserId();
            if (service.AssignTask(taskUser,id))
            {
                return Ok("task Assigned"); //kasle k ma kk you can do..
            }
            return BadRequest("MemberNotAssignedToProjectItSeems");
        }
        [HttpPut]
        [Route("[Action]")]
        public IActionResult EditStatus([FromBody] TaskStatusRequest taskStatus,Guid TaskID)
        {

            service.Edit<TaskModel, TaskStatusRequest>(taskStatus,TaskID,GetUserId());
            var updated = service.GetByID<TaskModel,TaskStatusResponse>(TaskID);
            return Ok(new { updateddata = updated });
        }
        

    }
}

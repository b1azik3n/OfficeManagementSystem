using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Tasks;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : BaseController
    {
        private readonly ITaskService service;

        public TaskController(ITaskService service, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskRequest task)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }
            service.AddNew<TaskModel,TaskRequest>(task,GetUserId());
            return Ok("added");

        }
        [HttpGet]

        public IActionResult GetAllTasks()
        {
            var list = service.GetAll<TaskModel, TaskAllResponse>();
            return Ok(list);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
            var task = service.GetByID(id);
            return Ok(task);
        }
        [HttpPut]
        [Route("{id}")]


        public IActionResult EditTask([FromBody] TaskRequest task, Guid id)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }
            if (service.CheckIfIdExists<Project>(task.ProjectId))
            {

                service.Edit<TaskModel, TaskRequest>(task, id, GetUserId());
                var updated = service.GetByID<TaskModel, TaskResponse>(id);
                return Ok(new { message = "Updated", updated });
            }
            return BadRequest();

        }
        [HttpDelete]
        [Route("{id}")]
            public IActionResult DeleteTask(Guid Id)
            {
               if( service.Remove<TaskModel,TaskRequest>(Id))
               {
                return Ok("Deleted");


               };
                return NotFound();
            }
       
    }
    
}

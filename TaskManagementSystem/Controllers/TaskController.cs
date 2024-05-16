using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Tasks;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService service;

        public TaskController(ITaskService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskRequest task)
        {
            service.CreateTask(task);
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
                service.Edit<TaskModel,TaskRequest>(task,id);
                var updated=service.GetByID<TaskModel,TaskRequest> (id);
                return Ok(new { message = "Updated", updated });

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

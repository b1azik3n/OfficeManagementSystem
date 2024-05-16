using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.GeneralService;
using TaskManagementSystem.Services.Projects;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService service;

        public ProjectController(IProjectService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] ProjectRequest project)
        {
            service.AddNew<Project,ProjectRequest>(project);
            return Ok("Added");

        }
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var list = service.GetAll<Project,ProjectResponse>();
            return Ok(list);
        }
        [HttpGet]
        [Route("{Id}")] //solve
        public IActionResult Get_A_Project(Guid Id) {
            var project = service.GetByID(Id);
            return Ok(project);
        }
        [HttpPut] //solve
        public IActionResult UpdateProject([FromBody] ProjectRequest project, Guid Id)
        {
            service.Edit<Project, ProjectRequest>(project, Id);
            var updated = service.GetByID<Project,ProjectRequest>(Id);
            return Ok(new { message = "Updated", updated });

        }
        [HttpDelete]
        public IActionResult DeleteProject(Guid id)
        {
            
            if(service.Remove <Project, ProjectRequest>(id))
            {
                return Ok("deleted");
            };
            return NotFound();
        }
       
        
    }

}

using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.GeneralService;
using TaskManagementSystem.Services.Projects;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        private readonly IProjectService service;

        public ProjectController(IProjectService service, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] ProjectRequest project)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }
            if (service.CheckIfIdExists<Client>(project.ClientId))
            {

                var id = GetUserId();
                service.AddNew<Project, ProjectRequest>(project, id);
                return Ok("Added");
            }
            return BadRequest();

        }
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var list = service.GetAll<Project,ProjectResponse>();
            return Ok(list);
        }
        [HttpGet]
        [Route("{Id}")] //solve
        public IActionResult Get_A_Project(Guid Id) 
        {
            if(service.CheckIfIdExists<Client>(Id))
            {

                var project = service.GetByID(Id);
                return Ok(project);
            }
            return BadRequest();
        }
        [HttpPut] //solve
        public IActionResult UpdateProject([FromBody] ProjectRequest project, Guid Id)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }
            service.Edit<Project, ProjectRequest>(project, Id,GetUserId());
            var updated = service.GetByID<Project,ProjectResponse>(Id);
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

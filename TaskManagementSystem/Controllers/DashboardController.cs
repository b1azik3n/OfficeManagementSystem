using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TaskManagementSystem.Services.Dashboard;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DashboardController : BaseController
    {
        private readonly IDashboardService service;

        public DashboardController(IHttpContextAccessor contextAccessor, IDashboardService service) : base(contextAccessor)
        {
            this.service = service;
        }
        //[HttpGet]
        //public IActionResult CompletedTasks()
        //{
        //    //simply list name of project and tasks

        //}
        //[HttpGet]
        //public IActionResult PendingTasks()
        //{
        //    //Display count, model : Taskname, ProjectName,TaskStatus

        //}
        //[HttpGet]
        //public IActionResult CurrentProjects()
        //{
        //    //Display count, model: Projectname, ClientName, ProjecStatus


        //}
        [HttpGet]
        public IActionResult CompletedProjects(Guid UserId)
        {
            var projects = service.GetCompletedProjects(UserId);
            return Ok(projects);
        }
        [HttpGet]
        public IActionResult CurrentProjects(Guid UserId)
        {
            var projects = service.GetCurrentProjects(UserId);
            return Ok(projects);
        }
        [HttpGet]
        public IActionResult CompletedTasks(Guid UserId)
        {
            var projects = service.GetCompletedTasks(UserId);
            return Ok(projects);
        }
        [HttpGet]
        public IActionResult PendingTasks(Guid UserId)
        {
            var projects = service.GetPendingTasks(UserId);
            return Ok(projects);
        }
        
        //manage date anusar you can ik..ez


    }



}

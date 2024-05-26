using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Dashboard;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : BaseController
    {
        private readonly IDashboardService service;

        public SummaryController(IHttpContextAccessor contextAccessor, IDashboardService service) : base(contextAccessor)
        {
            this.service = service;
        }
        [HttpGet] //manage date anusar you can ik..ez
        public IActionResult GetSummaryOfUsers()
        {

            //show username, completed tasks, pendingtasks, completed projects, pending projects
            var response = service.GetAllUsersSummary();
            return Ok(response);

        }
    }
}

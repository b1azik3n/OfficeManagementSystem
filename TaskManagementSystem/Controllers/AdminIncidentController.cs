using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Pkcs;
using TaskManagementSystem.Services.Incident;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AdminIncidentController : BaseController
    {
        private readonly IIncidentService service;

        public AdminIncidentController(IHttpContextAccessor contextAccessor, IIncidentService service) : base(contextAccessor)
        {
            this.service = service;
        }
            //}
            //[HttpGet]
            //public IActionResult GetListOfActiveIncident()
            //{
            //    //Name, Assigned_to_Rn , Description, ClientNAme, ProjectName
            //}
            //[HttpGet]
            //public IActionResult GetAllIncident()
            //{
            //    //Name, ClientName,Status:Active, Inactive only 
            //}
            //IncidentName, ClientName, Description,List, CreatedOn{ {Resolver, ListOf(Attempt, Method,
            //Time, SuccessfulOrNot,AttemptOn), PassedOn/Solved/AdminTransferred:Date}}
            [HttpGet]


            //Detailed Report
            //Summary Report
            public IActionResult GetIncidentHistory(Guid IncidentId)
            {
            return null;
            }
        
    }
}


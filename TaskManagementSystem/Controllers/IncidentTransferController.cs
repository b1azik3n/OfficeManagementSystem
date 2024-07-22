using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Incident;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentTransferController : ControllerBase
    {
        private readonly IIncidentService service;

        public IncidentTransferController(IIncidentService service)
        {
            this.service = service;
        }
        
    }
}

using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Incident;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentReportController : BaseController
    {
        private readonly IIncidentService service;

        public IncidentReportController(IHttpContextAccessor contextAccessor, IIncidentService service) : base(contextAccessor)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<List<IncidentReportDetailedResponse>> GetIncidentReportDetailed([FromBody] Guid ClientId)
        {
            var send = new IncidentReportDetailedRequest
            {
                ClientId = ClientId,
                UserId = GetUserId()
            };
           await service.GetIncidentReportDetailed(send);

        }
    }
}

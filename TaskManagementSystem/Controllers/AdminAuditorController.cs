using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminAuditorController : BaseController
    {
        private readonly IService service;

        public AdminAuditorController(IHttpContextAccessor contextAccessor, IService service) : base(contextAccessor)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Add([FromBody] AuditorRequest request)
        {
            service.AddNew<Auditor, AuditorRequest>(request, GetUserId());
            return Ok("Created");

        }
        [HttpPut]
        public IActionResult Edit([FromBody] AuditorRequest request, Guid AuditorId)
        {
            service.Edit<Auditor, AuditorRequest>(request, AuditorId, GetUserId());
            var updated = service.GetByID<Auditor, AuditorRequest>(AuditorId);
            return Ok(new { message = "Updated", updated });
        }
        [HttpDelete]
        public IActionResult Delete(Guid AuditorId)
        {
            service.Remove<Auditor, AuditorRequest>(AuditorId);
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var req = service.GetAll<Auditor, AuditorRequest>();
            return Ok(req);
        }
    }
}


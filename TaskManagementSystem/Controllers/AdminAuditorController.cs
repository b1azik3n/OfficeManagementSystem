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
        public IActionResult Add([FromBody] AuditorVM request)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }
            service.AddNew<Auditor, AuditorVM>(request, GetUserId());
            return Ok("Created");

        }
        [HttpPut]
        public IActionResult Edit([FromBody] AuditorVM request, Guid AuditorId)
        {
            service.Edit<Auditor, AuditorVM>(request, AuditorId, GetUserId());
            var updated = service.GetByID<Auditor, AuditorVM>(AuditorId);
            return Ok(new { message = "Updated", updated });
        }
        [HttpDelete]
        public IActionResult Delete(Guid AuditorId)
        {
            service.Remove<Auditor, AuditorVM>(AuditorId);
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var req = service.GetAll<Auditor, AuditorVM>();
            return Ok(req);
        }
    }
}


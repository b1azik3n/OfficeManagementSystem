using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : BaseController
    {
        private readonly IService service;

        public DesignationController(IService service, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
            var des = service.GetByID<Designation, DesignationRequest>(id);
            return Ok(des);
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = service.GetAll<Designation, DesignationRequest>();
            return Ok(roles);

        }
        [HttpPost]
        public IActionResult Create([FromBody] DesignationRequest designation)
        {
            var Id = GetUserId();

            service.AddNew<Designation, DesignationRequest>(designation, Id);
            return Ok("Created!");

        }
        [HttpPut]
        public IActionResult Update([FromBody] DesignationRequest task, Guid DesID)
        {

            service.Edit<Designation, DesignationRequest>(task, DesID, GetUserId());
            var updated = service.GetByID<Designation, DesignationRequest>(DesID);
            return Ok(new { message = "Updated", updated });

        }
    }
}

using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IService service;

        public DesignationController(IService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
           var des= service.GetByID<Designation,DesignationRequest>(id);
            return Ok(des);
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        { 
            var roles=service.GetAll<Designation,DesignationRequest>();
            return Ok(roles);
        
        }
        [HttpPost]
        public IActionResult Create([FromBody] DesignationRequest designation)
        {
            service.AddNew<Designation, DesignationRequest>(designation);
            return Ok("Created!");

        }
    }
}

using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AdminEmployeeController : BaseController
    {
        private readonly IService service;

        public AdminEmployeeController(IService service, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Add([FromBody] EmployeeRequest request)
        {
            service.AddNew<Employee, EmployeeRequest>(request, GetUserId());
            return Ok("Created");

        }
        [HttpPut]
        public IActionResult Edit([FromBody] EmployeeRequest request, Guid EmployeeId)
        {
            service.Edit<Employee, EmployeeRequest>(request, EmployeeId, GetUserId());
            var updated = service.GetByID<Employee, EmployeeRequest>(EmployeeId);
            return Ok(new { message = "Updated", updated });
        }
        [HttpDelete]
        public IActionResult Delete(Guid EmployeeId)
        {
            service.Remove<Employee, EmployeeRequest>(EmployeeId);
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
           var req= service.GetAll<Employee, EmployeeRequest>();
            return Ok(req);
        }
    }
}

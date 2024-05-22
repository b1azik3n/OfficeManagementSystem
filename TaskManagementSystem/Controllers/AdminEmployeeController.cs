using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskManagementSystem.Constants.AdminEmployee;
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
            if(!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x=> x.Errors).Select(x=> x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }
            if (service.CheckIfDuplicateEmail<Employee, EmployeeRequest>(request))
            {
                return BadRequest("EmailAlreadyExists!");
            }
            if (service.CheckIfDuplicatePhoneNumber<Employee, EmployeeRequest>(request))
            {
                return BadRequest("PhoneNumberAlreadyExists!");
            }
            service.AddNew<Employee, EmployeeRequest>(request, GetUserId());
            return Ok("Created");

        }
        [HttpGet]
        public IActionResult GetParticular(Guid id)
        {
            if (service.CheckIfIdExists<Employee>(id))
            {

                var task = service.GetByID<Employee, EmployeeRequest>(id);
                return Ok(task);
            }
            return BadRequest("Invalid Id");
        }
        [HttpPut]
        public IActionResult Edit([FromBody] EmployeeRequest request, Guid EmployeeId)
        {
            service.Edit<Employee, EmployeeRequest>(request, EmployeeId, GetUserId());
            var updated = service.GetByID<Employee, EmployeeRequest>(EmployeeId);
            return Ok(new { message= AdminEmployeeConstants.Updated, updated });
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

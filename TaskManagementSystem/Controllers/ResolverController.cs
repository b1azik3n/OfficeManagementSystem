using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Constants.AdminEmployee;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResolverController : BaseController
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IService service;

        public ResolverController(IHttpContextAccessor contextAccessor, IService service) : base(contextAccessor)
        {
            this.contextAccessor = contextAccessor;
            this.service = service;
        }

        [HttpPost]
        public IActionResult Add([FromBody] ResolverRequest request)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }

            var currentUserId = GetUserId();
            service.AddNew<Resolver, ResolverRequest>(request,currentUserId);
            return Ok("Created");

        }
        //[HttpGet]
        //public IActionResult GetParticular(Guid id)
        //{
        //    if (service.CheckIfIdExists<Resolver>(id))
        //    {

        //        var task = service.GetByID<Resolver, ResolverResponse>(id);
        //        return Ok(task);
        //    }
        //    return BadRequest("Invalid Id");
        //}
        [HttpPut]
        public IActionResult Edit([FromBody] EmployeeRequest request, Guid EmployeeId)
        {
            service.Edit<Employee, EmployeeRequest>(request, EmployeeId, GetUserId());
            var updated = service.GetByID<Employee, EmployeeRequest>(EmployeeId);
            return Ok(new { message = AdminEmployeeConstants.Updated, updated });
        }
        [HttpDelete]
        public IActionResult Delete(Guid EmployeeId)
        {
            service.Remove<Resolver, ResolverRequest>(EmployeeId);
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var req = service.GetAll<Employee, EmployeeRequest>();
            return Ok(req);
        }
    }
}


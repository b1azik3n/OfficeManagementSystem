using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Clients;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IClientService service;
        private readonly ILogger<ClientController> logger;

        public ClientController(IClientService service,IHttpContextAccessor contextAccessor, ILogger<ClientController> logger) : base(contextAccessor)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientRequest client)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(message);
            }
            if (service.CheckIfDuplicateEmail<Client, ClientRequest>(client))
            {
                return BadRequest("EmailAlreadyExists!");
            }
            if(service.CheckIfDuplicatePhoneNumber<Client, ClientRequest>(client))
            {
                return BadRequest("PhoneNumberAlreadyExists!");
            }
            var CurrentUserId=GetUserId();
            service.AddNew<Client, ClientRequest>(client,CurrentUserId);
            logger.LogInformation("Added New Client");
            return Ok("added");

        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            
            var list = service.GetAll<Client,ClientRequest>();
            return Ok(list);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
            if(service.CheckIfIdExists<Client>(id))
            {

                var task = service.GetByID<Client, ClientRequest>(id);
                return Ok(task);
            }
            return BadRequest("Invalid Id");
        }
        [HttpPut]
        [Route("{ClientId}")]


        public IActionResult UpdateClient([FromBody] ClientRequest client, Guid ClientId)
        {
            
            
                if (service.CheckIfDuplicateEmail<Client, ClientRequest>(client))
                {
                    return BadRequest("EmailAlreadyExists!");
                }
                if (service.CheckIfDuplicatePhoneNumber<Client, ClientRequest>(client))
                {
                    return BadRequest("PhoneNumberAlreadyExists!");
                }

                service.Edit<Client, ClientRequest>(client, ClientId, GetUserId());
                var updated = service.GetByID<Client, ClientRequest>(ClientId);
                return Ok(new { message = "Updated", updated });

            
            

        }
        [HttpDelete]
        


        public IActionResult DeleteClient(Guid Id)
        {
            if( service.Remove<Client, ClientRequest>(Id))
            {
                return Ok("Deleted");


            }
            return NotFound("User Doesn't Exist");

        }
    }
}

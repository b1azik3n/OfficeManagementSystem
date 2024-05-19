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
        public IActionResult CreateClient([FromBody] ClientRequest task)
        {
            var CurrentUserId=GetUserId();
            
            service.AddNew<Client, ClientRequest>(task,CurrentUserId);
            logger.LogInformation("Added New Client");
            return Ok("added");

        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            throw new NotImplementedException("Work FFS");
            var list = service.GetAll<Client,ClientRequest>();
            return Ok(list);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
            var task = service.GetByID<Client, ClientRequest>(id);
            return Ok(task);
        }
        [HttpPut]
        [Route("{ClientId}")]


        public IActionResult UpdateClient([FromBody] ClientRequest task, Guid ClientId)
        {
            
            service.Edit<Client, ClientRequest>(task, ClientId,GetUserId());
            var updated = service.GetByID<Client, ClientRequest>(ClientId);
            return Ok(new { message = "Updated", updated });

        }
        [HttpDelete]
        [Route("{Id}")]


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

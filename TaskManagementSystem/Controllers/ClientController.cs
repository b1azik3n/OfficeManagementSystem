using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Clients;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientRequest task)
        {
            service.AddNew<Client, ClientRequest>(task);
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
            var task = service.GetByID<Client, ClientRequest>(id);
            return Ok(task);
        }
        [HttpPut]
        [Route("{id}")]


        public IActionResult UpdateClient([FromBody] ClientRequest task, Guid id)
        {
            service.Edit<Client, ClientRequest>(task, id);
            var updated = service.GetByID<Client, ClientRequest>(id);
            return Ok(new { message = "Updated", updated });

        }
        [HttpDelete]
        [Route("{id}")]


        public IActionResult DeleteClient(Guid Id)
        {
            if( service.Remove<Client, ClientRequest>(Id))
            {
                return NotFound("User Doesn't Exist");

            }
            return Ok("Deleted");
        }
    }
}

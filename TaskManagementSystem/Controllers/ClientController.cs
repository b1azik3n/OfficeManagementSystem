using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Clients;


namespace TaskManagementSystem.Controllers
{
    /// <summary>
    /// Controller for managing clients.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IClientService service;
        private readonly ILogger<ClientController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController"/> class.
        /// </summary>
        /// <param name="service">The client service.</param>
        /// <param name="contextAccessor">The context accessor.</param>
        /// <param name="logger">The logger instance.</param>
        public ClientController(IClientService service, IHttpContextAccessor contextAccessor, ILogger<ClientController> logger)
            : base(contextAccessor)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Creates a new client.
        /// </summary>
        /// <param name="client">The client request object.</param>
        /// <returns>HTTP status code indicating the result of the operation.</returns>
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
            if (service.CheckIfDuplicatePhoneNumber<Client, ClientRequest>(client))
            {
                return BadRequest("PhoneNumberAlreadyExists!");
            }
            var currentUserId = GetUserId();
            service.AddNew<Client, ClientRequest>(client, currentUserId);
            logger.LogInformation("Added New Client");
            return Ok("added");
        }

        /// <summary>
        /// Gets all clients.
        /// </summary>
        /// <returns>A list of all clients.</returns>
        [HttpGet]
        public IActionResult GetAllClients()
        {
            var list = service.GetAll<Client, ClientRequest>();
            return Ok(list);
        }

        /// <summary>
        /// Gets a particular client by ID.
        /// </summary>
        /// <param name="id">The client ID.</param>
        /// <returns>The client with the specified ID, if it exists.</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
            if (service.CheckIfIdExists<Client>(id))
            {
                var client = service.GetByID<Client, ClientRequest>(id);
                return Ok(client);
            }
            return BadRequest("Invalid Id");
        }

        /// <summary>
        /// Updates an existing client.
        /// </summary>
        /// <param name="client">The updated client request object.</param>
        /// <param name="ClientId">The ID of the client to update.</param>
        /// <returns>HTTP status code indicating the result of the operation, along with the updated client.</returns>
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

        /// <summary>
        /// Deletes a client by ID.
        /// </summary>
        /// <param name="Id">The ID of the client to delete.</param>
        /// <returns>HTTP status code indicating the result of the operation.</returns>
        [HttpDelete]
        public IActionResult DeleteClient(Guid Id)
        {
            if (service.Remove<Client, ClientRequest>(Id))
            {
                return Ok("Deleted");
            }
            return NotFound("User Doesn't Exist");
        }
    }
}

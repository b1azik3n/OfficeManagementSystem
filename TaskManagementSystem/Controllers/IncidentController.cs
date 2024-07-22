using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Incident;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : BaseController
    {
        private readonly IIncidentService service;

        public IncidentController(IHttpContextAccessor contextAccessor, IIncidentService service) : base(contextAccessor)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult CreateIncident([FromBody] IncidentRequest request)
        {
            //This Creates New Incident And Returns The Id Of Newly Created.
            var newIncidentId = service.AddWithoutLogin<Incident, IncidentRequest>(request);

            //Assigns to LowLevel Resolver with lowest amount to active incident
            service.AssignToLowLevel(newIncidentId);
            return Ok();
        }
        [HttpPost]
        [Route("[Action]")]

        public IActionResult AddIncidentResolvingAttempt([FromBody] IncidentResolvingHistoryRequest request)
        {
            if (!service.CurrentUserAssignedToIncident(request.IncidentId, GetUserId()))
            {
                return BadRequest("NotAssignedToThisIncident");
            }

            service.AddAttempt(request, GetUserId());
            return Ok();

        }

        [HttpPost]
        [Route("[Action]")]



        public IActionResult TransferIncidentToHigherLevel(Guid IncidentResolverId)
        {
            var IncidentId = service.GetIncidentId(IncidentResolverId);
            //!!!!Check this function
            //check if the current logged in user is assigned to the Incident
            if (!service.CurrentUserAssignedToIncident(IncidentId, GetUserId()))
            {
                return BadRequest("NotAssignedToThisIncident");
            }

            //check if the Incident is active
            if (!service.IncidentIsActive(IncidentId))
            {
                return BadRequest("NotAssignedToYouAnymore. Lol!");
            }
            //Assign to higher level of resolver
            service.AssignToHigherLevel(IncidentResolverId);

            //Change the status to PassedOn.
            service.StatusChangeToPassedOn(IncidentResolverId);
            return Ok();
        }
        [HttpDelete]
        [Route("[Action]")]
        public IActionResult IncidentResolverDelete(Guid IncidentResolverId)
        {
            service.Remove<IncidentResolver,IncidentRequest>(IncidentResolverId);
            return Ok();
        }

        




        //ManualIncidentAssigment: Incident 
        //ManualIncidentTransfer: Exact Resolver.. Just extra + - update table ez..
        //Summary Incident tracking:By: Name,Level [[Attempt No.,time, Attempt Method: Success, Failed]]Array [Passed on: date, Passed to: ],,
        //Next level wala ko Name, Attempt No. Start from 1 again better and same thing..









    }

}

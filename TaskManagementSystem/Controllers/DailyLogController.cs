using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using TaskManagementSystem.Services.DailyLogs;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Controllers
{
    //public class TaskAuthorize : Attribute, IAuthorizationFilter
    //{
    //    public void OnAuthorization(AuthorizationFilterContext context)
    //    {
    //        var countryClaim = context.HttpContext.User.FindFirst(x => x.ValueType == ClaimTypes.Country);

    //        if (countryClaim.Value != "Nepal")
    //        {
    //            context.Result = new UnauthorizedResult();
    //        }
    //    }

    //}
    //[TaskAuthorize]

    [Route("api/[controller]")]
    [ApiController]
    public class DailyLogController : ControllerBase
    {
        private readonly ILogService logService;
        private readonly IHttpContextAccessor contextAccessor;

        public DailyLogController(ILogService logService, IHttpContextAccessor contextAccessor)
        {
            this.logService = logService;
            this.contextAccessor = contextAccessor;
        }

        [HttpPost]
        //[Authorize(Roles = "Employee")]
        public IActionResult SubmitLog([FromBody] DailyLogRequest log)
        {
            string UserId = GetUserIDFromToken();
            logService.AddNew<DailyLog,DailyLogRequest>(log,UserId);

            return Ok(new { message = "Submitted Succesfully" });


        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult ViewSpecific(Guid Id)
        {
            var loginfo = logService.ViewLog(Id);
            return Ok(loginfo);
        }


        [HttpGet]
        public IActionResult ViewAllLog()
        {
            var list=logService.GetAll<DailyLog,DailyLogRequest>();
            return Ok(list);

        }
        [HttpDelete] 
        public IActionResult DeleteLog(Guid Id)
        { 
            if( logService.Remove<DailyLog, DailyLogRequest>(Id))
            {
                return Ok("Deleted");

            }; 
           return NotFound();
        }

        protected string GetUserIDFromToken()
        {
            string token= contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return token;

        }
    }
}

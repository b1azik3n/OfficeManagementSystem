using DomainLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TaskManagementSystem.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor contextAccessor;

        protected BaseController(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        protected Guid GetUserId()
        {
            string Id = contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return Guid.Parse(Id);

        }
        

    }
}

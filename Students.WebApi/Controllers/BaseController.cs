using System;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Students.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[actions]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal int Id => !User.Identity.IsAuthenticated
            ? -1
            : int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}

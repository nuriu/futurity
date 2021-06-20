using Futurity.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Futurity.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ExceptionFilter]
    public abstract class FuturityBaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected FuturityBaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}

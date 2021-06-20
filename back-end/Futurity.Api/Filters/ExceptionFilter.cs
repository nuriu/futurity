using System.Net;
using Futurity.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Futurity.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            context.Result = new JsonResult(new { context.Exception.Message });
            base.OnException(context);
        }
    }
}

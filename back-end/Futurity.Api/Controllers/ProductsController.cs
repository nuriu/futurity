using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Futurity.Persistence.ViewModels;
using Futurity.Core.Exceptions;
using Futurity.Application.Queries.Products;
using System.Threading.Tasks;
using MediatR;
using System.Net.Mime;
using Futurity.Application.Commands.Products;

namespace Futurity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : FuturityBaseController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductViewModel>), 200)]
        [ProducesResponseType(typeof(ProductNotFoundException), 400)]
        public async Task<ActionResult<List<ProductViewModel>>> List([FromQuery] ListQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ActionResult<Unit>> Add([FromBody] AddCommand data)
        {
            return await Mediator.Send(data);
        }
    }
}

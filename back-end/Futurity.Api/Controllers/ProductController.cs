using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Futurity.Persistence.ViewModels;
using Futurity.Core.Exceptions;
using Futurity.Application.Queries.Products;
using System.Threading.Tasks;
using MediatR;

namespace Futurity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : FuturityBaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductViewModel>), 200)]
        [ProducesResponseType(typeof(ProductNotFoundException), 400)]
        public async Task<ActionResult<List<ProductViewModel>>> List([FromQuery] ListQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}

using System.Collections.Generic;
using FluentValidation;
using Futurity.Persistence;
using Futurity.Persistence.ViewModels;
using MediatR;

namespace Futurity.Application.Queries.Products
{
    public class ListQuery : PageableModel, IRequest<List<ProductViewModel>>
    {
    }

    public class ListQueryValidator : AbstractValidator<ListQuery>
    {
        public ListQueryValidator()
        {
            RuleFor(pm => pm.Page).GreaterThan(0);
            RuleFor(pm => pm.PageSize).GreaterThan(0);
        }
    }
}

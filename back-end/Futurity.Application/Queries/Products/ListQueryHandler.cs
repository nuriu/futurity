using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Futurity.Persistence;
using Futurity.Persistence.Contexts;
using Futurity.Persistence.ViewModels;
using MediatR;

namespace Futurity.Application.Queries.Products
{
    public class ListQueryHandler : IRequestHandler<ListQuery, List<ProductViewModel>>
    {
        private readonly FuturityMSSQLContext _context;

        public ListQueryHandler(FuturityMSSQLContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> Handle(ListQuery request, CancellationToken cancellationToken)
        {
            var productSet = await _context.Products.PagedToListAsync(request.Page, request.PageSize);
            return ProductViewModel.CreateFromProducts(productSet).ToList();
        }
    }
}

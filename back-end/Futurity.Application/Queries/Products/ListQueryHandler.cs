using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Futurity.Core.Entities;
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
            IQueryable<Product> productSet = _context.Products;

            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                productSet = productSet.Where(x => x.ProductName.Contains(request.Filter) || x.ProductDescription.Contains(request.Filter));
            }

            var products = await productSet.PagedToListAsync(request.Page, request.PageSize);

            return ProductViewModel.CreateFromProducts(products).ToList();
        }
    }
}

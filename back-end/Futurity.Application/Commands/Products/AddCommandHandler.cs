using System;
using System.Threading;
using System.Threading.Tasks;
using Futurity.Core.Entities;
using Futurity.Persistence.Contexts;
using MediatR;

namespace Futurity.Application.Commands.Products
{
    public class AddCommandHandler : IRequestHandler<AddCommand>
    {
        private readonly FuturityMSSQLContext _context;

        public AddCommandHandler(FuturityMSSQLContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductName = request.Name,
                ProductDescription = request.Description,
                UnitPrice = request.UnitPrice,
                UnitsInStock = request.UnitsInStock
            };

            _context.Products.Add(product);

            var success = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (success) return Unit.Value;

            throw new Exception("Problem saving changes.");
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Futurity.Core.Entities;

namespace Futurity.Persistence.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public static ProductViewModel CreateFromProduct(Product product)
        {
            var dto = new ProductViewModel
            {
                Id = product.ProductID,
                Name = product.ProductName,
                Description = product.ProductDescription,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            };

            return dto;
        }

        public static ICollection<ProductViewModel> CreateFromProducts(IEnumerable<Product> products)
        {
            return products.Select(p => CreateFromProduct(p)).ToList();
        }
    }
}

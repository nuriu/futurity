using System;
using System.Collections.Generic;
using System.Linq;
using Cemiyet.Persistence.Configurations;
using Futurity.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Futurity.Persistence.Contexts
{
    public static class FuturityMSSQLContextSeed
    {
        public static void Seed(FuturityMSSQLContext context)
        {
            SeedProducts(context);
        }

        private static void SeedProducts(FuturityMSSQLContext context)
        {
            if (context.Products.Any()) return;

            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                context.Products.Add(new Product
                {
                    ProductName = $"Product {i}",
                    ProductDescription = $"Description of {i}",
                    UnitPrice = (float)(random.NextDouble() * 100),
                    UnitsInStock = random.Next()
                });
            }

            context.SaveChanges();
        }
    }
}

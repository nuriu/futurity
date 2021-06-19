using System;

namespace Futurity.Core.Entities
{
    public partial class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}

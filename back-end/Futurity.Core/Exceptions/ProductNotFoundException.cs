using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Futurity.Core.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        protected ProductNotFoundException() : base()
        {
        }

        public ProductNotFoundException(int productId) : base($"Could not found any product with specified id: {productId}")
        {
        }

        public ProductNotFoundException(IEnumerable<int> productIds) : base("Could not found any product with specified ids.")
        {
        }

        protected ProductNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ProductNotFoundException(string message) : base(message)
        {
        }

        public ProductNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

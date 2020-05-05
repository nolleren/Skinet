using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductSpecifications : BaseSpecification<Product>
    {
        public ProductSpecifications()
        {
            AddInclude(_ => _.ProductType);
            AddInclude(_ => _.ProductBrand);
        }

        public ProductSpecifications(Guid id) : base(_ => _.Id == id)
        {
            AddInclude(_ => _.ProductType);
            AddInclude(_ => _.ProductBrand);
        }
    }
}
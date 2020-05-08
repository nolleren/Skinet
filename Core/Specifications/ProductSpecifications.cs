using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductSpecifications : BaseSpecification<Product>
    {
        public ProductSpecifications(ProductSpecParams productParams) : base(x => 
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
            AddInclude(_ => _.ProductType);
            AddInclude(_ => _.ProductBrand);
            AddOrderBy(_ => _.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(_ => _.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(_ => _.Price);
                        break;
                    case "nameAsc":
                        AddOrderBy(_ => _.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(_ => _.Name);
                        break;
                    default:
                        AddOrderBy(_ => _.Name);
                        break;
                }
            }
        }

        public ProductSpecifications(Guid id) : base(_ => _.Id == id)
        {
            AddInclude(_ => _.ProductType);
            AddInclude(_ => _.ProductBrand);
        }
    }
}
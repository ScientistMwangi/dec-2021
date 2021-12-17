using EcommerceCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.DataLayer.Repository
{
    public interface IProductCategoryRepo : IGenericRepository<ProductCategory>
    {

    }
    public class ProductCategoryRepo : GenericRepository<ProductCategory>, IProductCategoryRepo
    {
        public ProductCategoryRepo(EcommerceDbContext context)
           : base(context)
        {

        }
    }
}

using EcommerceCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.DataLayer.Repository
{
    public interface IProductTagRepo : IGenericRepository<ProductTag>
    {

    }
    public class ProductTagRepo : GenericRepository<ProductTag>, IProductTagRepo
    {
        public ProductTagRepo(EcommerceDbContext context)
           : base(context)
        {

        }
    }
}

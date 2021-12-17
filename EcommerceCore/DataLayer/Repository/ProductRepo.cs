using EcommerceCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.DataLayer.Repository
{
    public interface IProductRepo : IGenericRepository<Product>
    {

    }
    public class ProductRepo : GenericRepository<Product>, IProductRepo
    {
        public ProductRepo(EcommerceDbContext context)
           : base(context)
        {

        }
    }
}

using EcommerceCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.DataLayer.Repository
{
    public interface ICustomerOrderRepo : IGenericRepository<CustomerOrder>
    {

    }
    public class CustomerOrderRepo : GenericRepository<CustomerOrder>, ICustomerOrderRepo
    {
        public CustomerOrderRepo(EcommerceDbContext context)
           : base(context)
        {

        }
    }
}

using EcommerceCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.DataLayer.Repository
{
    public interface ICustomerOrderDetailRepo : IGenericRepository<CustomerOrderDetail>
    {

    }
    public class CustomerOrderDetailRepo : GenericRepository<CustomerOrderDetail>, ICustomerOrderDetailRepo
    {
        public CustomerOrderDetailRepo(EcommerceDbContext context)
           : base(context)
        {

        }
    }
}

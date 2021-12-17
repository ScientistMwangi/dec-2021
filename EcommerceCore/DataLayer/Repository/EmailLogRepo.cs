using EcommerceCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.DataLayer.Repository
{
     
    public interface IEmailLogRepo : IGenericRepository<EmailLog>
    {

    }
    public class EmailLogRepo : GenericRepository<EmailLog>, IEmailLogRepo
    {
        public EmailLogRepo(EcommerceDbContext context)
           : base(context)
        {

        }
    }
}

using EcommerceCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.DataLayer.Repository
{
    public interface IEmailTemplateRepo : IGenericRepository<EmailTemplate>
    {

    }
    public class EmailTemplateRepo : GenericRepository<EmailTemplate>, IEmailTemplateRepo
    {
        public EmailTemplateRepo(EcommerceDbContext context)
           : base(context)
        {

        }
    }
}


using EcommerceCore.Models;
using EcommerceCore.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.DataLayer
{
    public class EcommerceDbContext : IdentityDbContext<AppUser, Role, Guid>
    {
        public EcommerceDbContext()
        {
        }

        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {

        }

        public DbSet<SystemParameter> SystemParameters { get; set; }
       // public DbSet<AppUsers> Users { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

    }
}

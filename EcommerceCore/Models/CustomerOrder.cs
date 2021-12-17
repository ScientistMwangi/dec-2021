using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceCore.Models
{

    [Table("CustomerOrder")]
    public class CustomerOrder : EntityAudit
    {
        public decimal TotalCost { get; set; }
        public Guid UserId { get; set; }
        [NotMapped]
        public IdentityUser User { get; set; }
    }
}

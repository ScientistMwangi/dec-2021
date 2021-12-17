using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceCore.Models
{
    [Table("ProductTag")]
    public class ProductTag : EntityAudit
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceCore.Models
{
    [Table("Product")]
    public class Product : EntityAudit
    {
        public string ProductTags { get; set; }
        public int ProductCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get;set; }
        public decimal PricePerItem { get; set; }
        public decimal Quantity { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }
        public ProductCategory productCategory { get; set; }
    }
}

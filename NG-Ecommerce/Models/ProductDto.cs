using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NG_Ecommerce.Models
{
    public class ProductDto
    {
        public string ProductTags { get; set; }
        public int ProductCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int PricePerItem { get; set; }
        public int Quantity { get; set; }
    }
}

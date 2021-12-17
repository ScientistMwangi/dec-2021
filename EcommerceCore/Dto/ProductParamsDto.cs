using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.Dto
{
    public class ProductParamsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal Quantity { get; set; }
        public decimal SoldOut { get; set; }
    }
}

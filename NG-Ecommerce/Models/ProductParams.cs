using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NG_Ecommerce.Models
{
    public class ProductParams
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

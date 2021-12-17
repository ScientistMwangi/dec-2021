using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.Dto
{
    public class OrderOfProductsDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int PricePerItem { get; set; }

        public string Name { get; set; }
    }
}

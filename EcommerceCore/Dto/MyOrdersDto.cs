using EcommerceCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.Dto
{
    public class MyOrdersDto
    {
        public List<CustomerOrder> Orders { get; set; }
        public List<MyOrderDetails> ListOfMyOrderDetails { get; set; }
    }

    public class MyOrderDetails
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

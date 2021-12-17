using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceCore.Models
{
    [Table("CustomerOrderDetail")]
    public class CustomerOrderDetail
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerOrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public Decimal Quantity { get; set; }

        public Product Products{get;set;}

        public CustomerOrder CustomerOrders { get; set; }
    }
}

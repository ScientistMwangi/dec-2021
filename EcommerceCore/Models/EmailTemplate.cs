using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceCore.Models
{
    [Table("EmailTemplate")]
    public class EmailTemplate : EntityAudit
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public EcommerceConstants.EmailTemplateType TemplateType { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public string PurchasedItems { get; set; }

    }
}

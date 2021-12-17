using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceCore.Models
{
    [Table("EmailLog")]
    public class EmailLog : EntityAudit
    {
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public EcommerceConstants.EmailStatus EmailStatus { get; set; }
        public string EmailContent { get; set; }
        public string ExceptionIssue { get; set; }
    }
}

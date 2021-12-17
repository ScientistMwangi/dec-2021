using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceCore.Models
{
    public class EntityAudit
    {
        public EntityAudit()
        {
            this.DateCreated = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        
        public string CreatedBy { get; set; }
       
        public DateTime DateCreated { get; set; }

        public string LastModifiedBy { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}

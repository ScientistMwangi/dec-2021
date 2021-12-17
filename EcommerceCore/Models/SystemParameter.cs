using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceCore.Models
{
    public class SystemParameter : EntityAudit
    {
        [Required]
        [MaxLength(250)]
        //[Index(IsUnique = true)]
        public String ParameterName { get; set; }
        [Required]
        public String ParameterValue { get; set; }
        [Required]
        public String ParameterType { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string Culture { get; set; }

    }
}

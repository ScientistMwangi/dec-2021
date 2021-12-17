using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCore.Models
{
    public class EcommerceConstants
    {
        public enum EmailTemplateType{
            Register = 0,
            ForgetPassword = 1,
            SendOrder = 2,
            Promotion = 3
        }

        public enum EmailStatus
        {
            NotSent = 0,
            Sent = 1,
            Failed = 2
        }
    }
}

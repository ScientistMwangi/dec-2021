using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NG_Ecommerce.Helpers
{
    public class JwtSettings
    {
        public string Issuer { get; set; }

        public string Secret { get; set; }

        public int ExpirationInDays { get; set; }
    }
}

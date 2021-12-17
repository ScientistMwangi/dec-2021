using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NG_Ecommerce.Models.Responses
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
    }

}

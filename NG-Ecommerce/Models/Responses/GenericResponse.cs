using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NG_Ecommerce.Models.Responses
{
    public class GenericResponse<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public T ReponseObject { get;set;}

        public List<T> ListOfReponseObject { get; set; }
    }
}

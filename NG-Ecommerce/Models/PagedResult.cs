using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NG_Ecommerce.Models
{
    public class PagedResult<T> :  PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }
        public List<List<T>> Results2 { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}

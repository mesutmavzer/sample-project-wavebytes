using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.Contract
{
    public class ApiPageResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Total { get; set; }
    }
}

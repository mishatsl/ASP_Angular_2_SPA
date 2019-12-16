using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Angular_2_SPA.Models
{
    public class PagingInfo
    {
        public int currentPage { set; get; }
        public int totalItems { set; get; } // total numbar of page not items
        public int maxSize { set; get; } // max page size
    }
}

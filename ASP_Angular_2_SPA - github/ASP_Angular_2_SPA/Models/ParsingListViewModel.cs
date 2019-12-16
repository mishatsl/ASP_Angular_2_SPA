using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Angular_2_SPA.Models
{
    public class ParsingListViewModel
    {       
        public PagingInfo pagingInfo { set; get; }

        public IEnumerable<ParsingInfoSimplified> parsingInfoSimplifieds { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Models.PagedRequest
{
    public class RequestFilters
    {
        public RequestFilters()
        {
            Filters = new List<Filter>();
        }

        public FilterLogicalOperators LogicalOperators { get; set; }
        public IList<Filter> Filters { get; set; }
    }
}

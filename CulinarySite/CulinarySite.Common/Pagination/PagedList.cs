using System.Collections.Generic;
using System.Linq;

namespace CulinarySite.Common.Pagination
{
    public class PagedList<T>
    {
        public int TotalCount { get; private set; }
        public List<T> Items { get; set; }

        public PagedList(IQueryable<T> items, PagingParameters pagingParameters)
        {
            this.TotalCount = items.Count();
            this.Items = items.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize).Take(pagingParameters.PageSize).ToList();
        }

        public PagedList(IEnumerable<T> items, int totalCount)
        {
            this.TotalCount = totalCount;
            this.Items = items.ToList();
        }

    }
}

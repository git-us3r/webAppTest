using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace webAppTest.Models
{
    public interface IPagedResult
    {
        int Page { get; }
        int TotalPages { get; }
    }

    public class PagedResult<T> : List<T>, IPagedResult
    {
        private const int PageSize = 1;
        public int Page { get; private set; }
        public int TotalPages { get; private set; }

        public PagedResult(IQueryable<T> query, int page)
        {
            this.Page = page;
            this.TotalPages = (int)Math.Ceiling(query.Count() / (double)PageSize);
            this.AddRange(query.Skip(page * PageSize).Take(PageSize));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductApp.DAL.Paging
{
    public class PagedList<T> : List<T>
	{
		public int PageNumber { get; private set; }
		public int TotalPages { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }

		public bool HasPrevious => PageNumber > 1;
		public bool HasNext => PageNumber < TotalPages;

		public PagedList(List<T> items, int count, int pageNumber, int pageSize, int totalPages)
		{
			TotalCount = count;
			PageSize = pageSize;
			PageNumber = pageNumber;
			TotalPages = totalPages;

			AddRange(items);
		}

		public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			var totalPages = (int)Math.Ceiling(count / (double)pageSize);
			if (pageNumber > totalPages)
				pageNumber = totalPages;

			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			return new PagedList<T>(items, count, pageNumber, pageSize, totalPages);
		}
	}
}

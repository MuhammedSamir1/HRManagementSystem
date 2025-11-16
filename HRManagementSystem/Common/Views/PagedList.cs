using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Common.Views
{
    public class PagedList<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; } = new List<T>();

        //  ?????  ??? ??? ???? ?????   
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList() { }


        public static async Task<PagedList<T>> CreateAsync<TEntity>(
            IQueryable<TEntity> source,
            int pageNumber,
            int pageSize,
            IMapper mapper,
            CancellationToken ct)
            where TEntity : class
        {
            var count = await source.CountAsync(ct);


            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<T>(mapper.ConfigurationProvider)
                .ToListAsync(ct);

            var pagedList = new PagedList<T>
            {
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                PageSize = pageSize,
                TotalCount = count,
                Items = items
            };

            return pagedList;
        }
    }
}


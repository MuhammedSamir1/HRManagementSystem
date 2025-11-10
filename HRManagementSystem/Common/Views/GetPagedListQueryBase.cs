namespace HRManagementSystem.Common.Views
{
    public record GetPagedListQueryBase<TDto> : IRequest<RequestResult<PagedList<TDto>>>
    {

        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;

        //   Sorting 
        public string? SortBy { get; init; }
        public string? SortDirection { get; init; } = "asc"; // asc أو desc
    }
}

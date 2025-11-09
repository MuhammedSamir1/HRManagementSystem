using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.HolidayManagement.Common.DTOs;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Dynamic.Core;
using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.HolidayManagement.GetAllHolidays.Queries
{
    public sealed class GetAllHolidaysQueryHandler : RequestHandlerBase<GetAllHolidaysQuery, RequestResult<PagedList<ViewHolidayDto>>, Holiday, int>
    {
        public GetAllHolidaysQueryHandler(RequestHandlerBaseParameters<Holiday, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<PagedList<ViewHolidayDto>>> Handle(GetAllHolidaysQuery request, CancellationToken ct)
        {
            
            var query = _generalRepo.Get(h => !h.IsDeleted,ct);

        
            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(h => h.Name.Contains(request.Name));

            if (request.CompanyId.HasValue)
                query = query.Where(h => h.CompanyId == request.CompanyId.Value);

            if (request.IsMandatory.HasValue)
                query = query.Where(h => h.IsMandatory == request.IsMandatory.Value);

            query = ApplyDynamicSorting(query, request.SortBy, request.SortDirection);

         
            var pagedList = await PagedList<ViewHolidayDto>.CreateAsync(
                query,
                request.PageNumber,
                request.PageSize,
                _mapper,
                ct
            );

            return RequestResult<PagedList<ViewHolidayDto>>.Success(pagedList);
        }

        /// <summary>
        /// تطبق الـ Sorting   .
        /// </summary>
        private IQueryable<Holiday> ApplyDynamicSorting(IQueryable<Holiday> query, string? sortBy, string? sortDirection)
        {
        
            var defaultSort = nameof(Holiday.Id);

            var ordering = string.IsNullOrWhiteSpace(sortBy) ? defaultSort : sortBy;

        
            var direction = (sortDirection?.ToLower() == "desc") ? "descending" : "ascending";

            // بناء سلسلة الـ Dynamic LINQ
            var orderingString = $"{ordering} {direction}";

            try
            {
                
                return query.OrderBy(orderingString);
            }
            catch (ParseException)
            {
           
                return query.OrderBy(defaultSort);
            }
        }
    }
}

using AutoMapper.QueryableExtensions;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetAllShifts.Queries
{
    public sealed record GetAllShiftsQuery : IRequest<RequestResult<IEnumerable<ViewShiftDto>>>;

    public sealed class GetAllShiftsQueryHandler : RequestHandlerBase<GetAllShiftsQuery,
        RequestResult<IEnumerable<ViewShiftDto>>, Shift, Guid>
    {
        public GetAllShiftsQueryHandler(RequestHandlerBaseParameters<Shift, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<IEnumerable<ViewShiftDto>>> Handle(GetAllShiftsQuery request, CancellationToken ct)
        {
            var shifts = await _generalRepo.Get(x => !x.IsDeleted, ct)
               .ProjectTo<ViewShiftDto>(_mapper.ConfigurationProvider)
               .ToListAsync(ct);

            if (shifts is null)
                return RequestResult<IEnumerable<ViewShiftDto>>.Failure(ErrorCode.ShiftNotFound);

            return RequestResult<IEnumerable<ViewShiftDto>>.Success(shifts);
        }
    }
}



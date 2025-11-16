using AutoMapper.QueryableExtensions;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftById.Queries
{
    public sealed record GetShiftByIdQuery(Guid Id) : IRequest<RequestResult<ViewShiftByIdDto>>;

    public sealed class GetShiftByIdQueryHandler : RequestHandlerBase<GetShiftByIdQuery,
        RequestResult<ViewShiftByIdDto>, Shift, Guid>
    {
        public GetShiftByIdQueryHandler(RequestHandlerBaseParameters<Shift, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewShiftByIdDto>> Handle(GetShiftByIdQuery request, CancellationToken ct)
        {
            var shift = await _generalRepo.Get(x => x.Id == request.Id && !x.IsDeleted, ct)
                .ProjectTo<ViewShiftByIdDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);

            if (shift is null)
                return RequestResult<ViewShiftByIdDto>.Failure(ErrorCode.ShiftNotFound);

            return RequestResult<ViewShiftByIdDto>.Success(shift);
        }
    }
}



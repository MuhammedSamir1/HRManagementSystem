using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.StateManagement.GetStateById.Queries
{
    public sealed record GetStateByIdQuery(Guid Id) : IRequest<RequestResult<ViewStateDto>>;

    public sealed class GetStateByIdQueryHandler : RequestHandlerBase<GetStateByIdQuery,
        RequestResult<ViewStateDto>, State, Guid>
    {
        public GetStateByIdQueryHandler(RequestHandlerBaseParameters<State, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewStateDto>> Handle(GetStateByIdQuery request, CancellationToken ct)
        {

            var state = await _generalRepo.Get(x => x.Id == request.Id && !x.IsDeleted, ct)
                .FirstOrDefaultAsync(ct);
            var stateDto = _mapper.Map<ViewStateDto>(state);

            if (stateDto is null)
                return RequestResult<ViewStateDto>.Failure(ErrorCode.StateNotFound);

            return RequestResult<ViewStateDto>.Success(stateDto);
        }
    }
}


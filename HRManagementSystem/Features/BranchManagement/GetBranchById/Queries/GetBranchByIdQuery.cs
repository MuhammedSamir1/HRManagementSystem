using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.BranchManagement.GetBranchById.Queries
{
    public sealed record GetBranchByIdQuery(Guid Id) : IRequest<RequestResult<ViewBranchByIdDto>>;

    public sealed class GetBranchByIdQueryHandler : RequestHandlerBase<GetBranchByIdQuery,
        RequestResult<ViewBranchByIdDto>, Branch, Guid>
    {
        public GetBranchByIdQueryHandler(RequestHandlerBaseParameters<Branch, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewBranchByIdDto>> Handle(GetBranchByIdQuery request, CancellationToken ct)
        {
            var branch = await _generalRepo.Get(x => x.Id == request.Id && !x.IsDeleted, ct)
                .ProjectTo<ViewBranchByIdDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);

            if (branch is null)
                return RequestResult<ViewBranchByIdDto>.Failure(ErrorCode.BranchNotFound);

            return RequestResult<ViewBranchByIdDto>.Success(branch);
        }
    }
}


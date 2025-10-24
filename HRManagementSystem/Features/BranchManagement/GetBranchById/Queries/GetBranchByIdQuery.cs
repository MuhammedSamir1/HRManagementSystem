using AutoMapper.QueryableExtensions;
using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.BranchManagement.GetBranchById.Queries
{
    public sealed record GetBranchByIdQuery(int Id) : IRequest<RequestResult<ViewBranchByIdDto>>;

    public sealed class GetBranchByIdQueryHandler : RequestHandlerBase<GetBranchByIdQuery,
        RequestResult<ViewBranchByIdDto>, Branch, int>
    {
        public GetBranchByIdQueryHandler(RequestHandlerBaseParameters<Branch, int> parameters)
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

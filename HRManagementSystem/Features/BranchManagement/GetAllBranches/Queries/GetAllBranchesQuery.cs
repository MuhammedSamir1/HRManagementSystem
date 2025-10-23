using AutoMapper.QueryableExtensions;
using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.BranchManagement.GetBranchById;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.BranchManagement.GetAllBranches.Queries
{
    public sealed record GetAllBranchesQuery : IRequest<RequestResult<ViewBranchDto>>;

    public sealed class GetBranchByIdQueryHandler : RequestHandlerBase<GetAllBranchesQuery,
        RequestResult<ViewBranchDto>, Branch, int>
    {
        public GetBranchByIdQueryHandler(RequestHandlerBaseParameters<Branch, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewBranchDto>> Handle(GetAllBranchesQuery request, CancellationToken ct)
        {
            var branch = await _generalRepo.Get(x => !x.IsDeleted, ct)
                .ProjectTo<ViewBranchDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);

            if (branch is null)
                return RequestResult<ViewBranchDto>.Failure(ErrorCode.NoBranchesFound);

            return RequestResult<ViewBranchDto>.Success(branch);
        }
    }
}

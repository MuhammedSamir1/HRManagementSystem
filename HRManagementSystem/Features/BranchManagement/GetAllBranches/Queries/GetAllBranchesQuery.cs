using AutoMapper.QueryableExtensions;
using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.BranchManagement.GetAllBranches.Queries
{
    public sealed record GetAllBranchesQuery : IRequest<RequestResult<IEnumerable<ViewBranchDto>>>;

    public sealed class GetAllBranchesQueryHandler : RequestHandlerBase<GetAllBranchesQuery,
        RequestResult<IEnumerable<ViewBranchDto>>, Branch, int>
    {
        public GetAllBranchesQueryHandler(RequestHandlerBaseParameters<Branch, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<IEnumerable<ViewBranchDto>>> Handle(GetAllBranchesQuery request, CancellationToken ct)
        {
            var branch = await _generalRepo.Get(x => !x.IsDeleted, ct)
                .ProjectTo<ViewBranchDto>(_mapper.ConfigurationProvider)
                .ToListAsync(ct);

            if (branch is null)
                return RequestResult<IEnumerable<ViewBranchDto>>.Failure(ErrorCode.NoBranchesFound);

            return RequestResult<IEnumerable<ViewBranchDto>>.Success(branch);
        }
    }
}

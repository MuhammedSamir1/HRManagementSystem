using HRManagementSystem.Common.Views.Response;
using MediatR;

namespace HRManagementSystem.Features.Common.BranchCommon.Queries
{
    public sealed record IsBranchValidQuery(int BranchId) : IRequest<RequestResult<bool>>;
}

namespace HRManagementSystem.Features.Common.BranchCommon.Queries
{
    public sealed record IsBranchValidQuery(Guid BranchId) : IRequest<RequestResult<bool>>;
}


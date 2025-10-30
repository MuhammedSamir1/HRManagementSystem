namespace HRManagementSystem.Features.Common.BranchCommon.Queries
{
    public sealed record IsBranchValidQuery(int BranchId) : IRequest<RequestResult<bool>>;
}

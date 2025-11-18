using HRManagementSystem.Data.Models.Scopes;
using HRManagementSystem.Features.Common.ScopeCommon.Queries;
using HRManagementSystem.Features.ScopeManagement.AddScope.Commands;

namespace HRManagementSystem.Features.ScopeManagement.EnsureScope.Commands
{
    public sealed record EnsureScopeCommand(
        Guid OrganizationId,
        Guid CompanyId,
        Guid? BranchId,
        Guid? DepartmentId,
        Guid? TeamId) : IRequest<RequestResult<Guid>>;

    public sealed class EnsureScopeCommandHandler
        : RequestHandlerBase<EnsureScopeCommand, RequestResult<Guid>, Scope, Guid>
    {
        public EnsureScopeCommandHandler(RequestHandlerBaseParameters<Scope, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<Guid>> Handle(EnsureScopeCommand request, CancellationToken ct)
        {
            var existsResult = await _mediator.Send(
                new ScopeHierarchyExistsQuery(
                    request.OrganizationId,
                    request.CompanyId,
                    request.BranchId,
                    request.DepartmentId,
                    request.TeamId), ct);

            if (!existsResult.isSuccess)
            {
                return RequestResult<Guid>.Failure(existsResult.message, existsResult.errorCode);
            }

            if (existsResult.data)
            {
                var existingScope = await _mediator.Send(
                    new GetScopeByHierarchyQuery(
                        request.OrganizationId,
                        request.CompanyId,
                        request.BranchId,
                        request.DepartmentId,
                        request.TeamId), ct);

                return existingScope;
            }

            var addResult = await _mediator.Send(
                new AddScopeCommand(
                    request.OrganizationId,
                    request.CompanyId,
                    request.BranchId,
                    request.DepartmentId,
                    request.TeamId), ct);

            return addResult;
        }
    }
}


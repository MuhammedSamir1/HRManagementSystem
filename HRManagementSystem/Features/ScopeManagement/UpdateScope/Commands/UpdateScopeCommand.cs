using HRManagementSystem.Data.Models.Scopes;
using HRManagementSystem.Features.Common.ScopeCommon.Queries;

namespace HRManagementSystem.Features.ScopeManagement.UpdateScope.Commands
{
    public sealed record UpdateScopeCommand(
        Guid Id,
        Guid OrganizationId,
        Guid CompanyId,
        Guid BranchId,
        Guid DepartmentId,
        Guid TeamId) : IRequest<RequestResult<bool>>;

    public sealed class UpdateScopeCommandHandler : RequestHandlerBase<UpdateScopeCommand, RequestResult<bool>, Scope, Guid>
    {
        public UpdateScopeCommandHandler(RequestHandlerBaseParameters<Scope, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UpdateScopeCommand request, CancellationToken ct)
        {
            var duplicateCheckResult = await _mediator.Send(new ScopeHierarchyExistsQuery(
                request.OrganizationId,
                request.CompanyId,
                request.BranchId,
                request.DepartmentId,
                request.TeamId,
                request.Id), ct);

            if (!duplicateCheckResult.isSuccess)
            {
                return RequestResult<bool>.Failure(duplicateCheckResult.message, duplicateCheckResult.errorCode);
            }

            if (duplicateCheckResult.data)
            {
                return RequestResult<bool>.Failure("Another scope already exists for the provided hierarchy.", ErrorCode.Conflict);
            }

            var scope = await _generalRepo.GetByIdWithTracking(request.Id);

            if (scope == null || scope.IsDeleted)
            {
                return RequestResult<bool>.Failure("Scope not found.", ErrorCode.NotFound);
            }

            scope.OrganizationId = request.OrganizationId;
            scope.CompanyId = request.CompanyId;
            scope.BranchId = request.BranchId;
            scope.DepartmentId = request.DepartmentId;
            scope.TeamId = request.TeamId;

            var isUpdated = await _generalRepo.UpdateAsync(scope, ct);

            if (!isUpdated)
            {
                return RequestResult<bool>.Failure("Scope wasn't updated successfully!", ErrorCode.InternalServerError);
            }

            return RequestResult<bool>.Success(true, "Scope updated successfully!");
        }
    }
}


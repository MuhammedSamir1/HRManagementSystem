using HRManagementSystem.Data.Models.Scopes;
using HRManagementSystem.Features.Common.ScopeCommon.Queries;

namespace HRManagementSystem.Features.ScopeManagement.AddScope.Commands
{
    public sealed record AddScopeCommand(
        Guid OrganizationId,
        Guid CompanyId,
        Guid? BranchId,
        Guid? DepartmentId,
        Guid? TeamId) : IRequest<RequestResult<Guid>>;

    public sealed class AddScopeCommandHandler : RequestHandlerBase<AddScopeCommand, RequestResult<Guid>, Scope, Guid>
    {
        public AddScopeCommandHandler(RequestHandlerBaseParameters<Scope, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<Guid>> Handle(AddScopeCommand request, CancellationToken ct)
        {
            var hierarchyExistsResult = await _mediator.Send(new ScopeHierarchyExistsQuery(
                request.OrganizationId,
                request.CompanyId,
                request.BranchId,
                request.DepartmentId,
                request.TeamId), ct);

            if (!hierarchyExistsResult.isSuccess)
            {
                return RequestResult<Guid>.Failure(hierarchyExistsResult.message, hierarchyExistsResult.errorCode);
            }

            if (hierarchyExistsResult.data)
            {
                return RequestResult<Guid>.Failure("Scope already exists for the provided hierarchy.", ErrorCode.Conflict);
            }

            var scope = _mapper.Map<Scope>(request);
            var isAdded = await _generalRepo.AddAsync(scope, ct);

            if (!isAdded)
            {
                return RequestResult<Guid>.Failure("Scope wasn't added successfully!", ErrorCode.InternalServerError);
            }

            return RequestResult<Guid>.Success(scope.Id, "Scope added successfully!");
        }
    }
}


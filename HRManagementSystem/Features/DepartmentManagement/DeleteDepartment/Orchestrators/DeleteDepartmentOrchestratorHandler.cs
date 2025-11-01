using HRManagementSystem.Features.Common.IsAnyChildAssignedGeneric;
using HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Orchestrators;

public sealed class DeleteDepartmentOrchestratorHandler : RequestHandlerBase<DeleteDepartmentOrchestrator,
   RequestResult<bool>, Department, int>
{
    public DeleteDepartmentOrchestratorHandler(RequestHandlerBaseParameters<Department, int> parameters) : base(parameters)
    { }

    public override async Task<RequestResult<bool>> Handle(DeleteDepartmentOrchestrator request, CancellationToken ct)
    {
        // Check if any Team assigned to this Department 

        var hasTeams = await _mediator.Send(new IsAnyChildAssignedQuery<
            Department, Team, int>(request.departmentId), ct);
        if (hasTeams.data)
        {
            return RequestResult<bool>.Failure("Cannot delete department. There are teams assigned to this department.");
        }

        var isDeleted = await _mediator.Send(new DeleteDepartmentCommand(request.departmentId));

        if (!isDeleted.isSuccess) return RequestResult<bool>.Failure(isDeleted.message, isDeleted.errorCode);
        return RequestResult<bool>.Success(isDeleted.isSuccess, isDeleted.message);
    }
}
using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Data.Models.Scopes;
using HRManagementSystem.Features.Common.AssignationManagement.AddAssignation.Orchestrator;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.ShiftScopeManagement.AssignShiftScope;

public class Handler : AddAssignationOrchestratorCommandHandler<ShiftScope>
{
    public Handler(
        RequestHandlerBaseParameters<ShiftScope,Guid> parameters
    ) : base(parameters)
    {
    }
}

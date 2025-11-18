using HRManagementSystem.Data.Models.Scopes;
using HRManagementSystem.Features.Common.AssignationManagement.AddAssignation.Orchestrator;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.ShiftScopeManagement.AssignShiftScope;

[ApiGroup("Shift Scope Management")]
public sealed class AssignShiftScopeEndPoint : BaseEndPoint<AssignShiftScopeViewModel, ResponseViewModel<CreatedIdDto>>
{
    public AssignShiftScopeEndPoint(EndPointBaseParameters<AssignShiftScopeViewModel> parameters)
        : base(parameters) { }

    [HttpPost]
    public async Task<ResponseViewModel<CreatedIdDto>> AssignShiftScope([FromBody] AssignShiftScopeViewModel model)
    {
        var validationResult = ValidateRequest(model);
        if (!validationResult.isSuccess)
        {
            return ResponseViewModel<CreatedIdDto>.Failure(validationResult.errorCode);
        }


        var result = await _mediator.Send(new AddAssignationOrchestratorCommand<ShiftScope>(model.shiftId, model.scopeId));

        if (!result.isSuccess) return ResponseViewModel<CreatedIdDto>.Failure(result.message, result.errorCode);
        var mapped = _mapper.Map<CreatedIdDto>(result.data);
        return ResponseViewModel<CreatedIdDto>.Success(mapped, "Shift Scope Assigned Successfully!");
    }
}

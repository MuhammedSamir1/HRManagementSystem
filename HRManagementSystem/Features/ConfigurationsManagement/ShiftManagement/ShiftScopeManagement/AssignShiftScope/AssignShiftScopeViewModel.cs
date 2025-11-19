using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.ShiftScopeManagement.AssignShiftScope;

public sealed record AssignShiftScopeViewModel(Guid shiftId, Guid scopeId);
public sealed class AssignShiftScopeViewModelValidator : AbstractValidator<AssignShiftScopeViewModel>
{
    public AssignShiftScopeViewModelValidator()
    {
        RuleFor(x => x.shiftId)
            .NotEmpty().WithMessage("ShiftId is required.");
        RuleFor(x => x.scopeId)
            .NotEmpty().WithMessage("ScopeId is required.");
    }
}


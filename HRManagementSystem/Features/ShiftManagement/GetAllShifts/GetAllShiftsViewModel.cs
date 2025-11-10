using FluentValidation;

namespace HRManagementSystem.Features.ShiftManagement.GetAllShifts
{
    public sealed record GetAllShiftsViewModel;


    public sealed class GetAllShiftsViewModelValidator : AbstractValidator<GetAllShiftsViewModel>
    {
        public GetAllShiftsViewModelValidator() { }
    }
}


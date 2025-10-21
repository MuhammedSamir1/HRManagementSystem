using FluentValidation;

namespace HRManagementSystem.Features.BranchManagement.GetBranchById
{
    public sealed record GetBranchByIdViewModel(int Id);


    public sealed class GetBranchByIdViewModelValidator : AbstractValidator<GetBranchByIdViewModel>
    {
        public GetBranchByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
              .NotEmpty().WithMessage("Id is required.")
              .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}

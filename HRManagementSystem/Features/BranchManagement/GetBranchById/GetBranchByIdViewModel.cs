using FluentValidation;

namespace HRManagementSystem.Features.BranchManagement.GetBranchById
{
    public sealed record GetBranchByIdViewModel(Guid Id);


    public sealed class GetBranchByIdViewModelValidator : AbstractValidator<GetBranchByIdViewModel>
    {
        public GetBranchByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
              .NotEmpty().WithMessage("Id is required.")
              .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0");
        }
    }
}



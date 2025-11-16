using FluentValidation;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch
{
    public sealed record DeleteBranchViewModel(Guid Id);



    public sealed class DeleteBranchViewModelValidator : AbstractValidator<DeleteBranchViewModel>
    {
        public DeleteBranchViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0");
        }
    }
}



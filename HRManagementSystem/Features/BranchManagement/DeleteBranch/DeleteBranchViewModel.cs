using FluentValidation;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch
{
    public sealed record DeleteBranchViewModel(int Id);



    public sealed class DeleteBranchViewModelValidator : AbstractValidator<DeleteBranchViewModel>
    {
        public DeleteBranchViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}

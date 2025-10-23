using FluentValidation;

namespace HRManagementSystem.Features.BranchManagement.GetAllBranches
{
    public sealed record GetAllBranchesViewModel;
    

    public sealed class GetAllBranchesViewModelValidator : AbstractValidator<GetAllBranchesViewModel>
    {
        public GetAllBranchesViewModelValidator() { }
    }
}

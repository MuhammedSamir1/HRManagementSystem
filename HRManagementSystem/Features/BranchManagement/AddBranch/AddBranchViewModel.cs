using FluentValidation;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.ViewModels;

namespace HRManagementSystem.Features.BranchManagement.AddBranch
{
    public sealed record AddBranchViewModel(string Name, string? Description, Guid CompanyId,
        string Code, AddBranchAddressViewModel Address);



    public sealed class AddBranchViewModelValidator : AbstractValidator<AddBranchViewModel>
    {
        public AddBranchViewModelValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MinimumLength(2).WithMessage("Name must be at least 2 chars.")
               .MaximumLength(200).WithMessage("Name must be at most 200 chars.")
               .Must(v => v!.Trim().Length <= 200);


            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Legal name must be at most 1000 chars.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .MaximumLength(100).WithMessage("Code must be at most 100 chars.")
                .MaximumLength(200).WithMessage("Code must be at most 200 chars.")
                .Must(v => v!.Trim().Length <= 100);

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Address is required.")
                .SetValidator(new AddBranchAddressViewModelValidator());
        }
    }
}


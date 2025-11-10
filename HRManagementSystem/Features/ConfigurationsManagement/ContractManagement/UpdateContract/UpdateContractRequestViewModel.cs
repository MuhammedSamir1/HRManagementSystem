using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.UpdateContract
{
    public record UpdateContractRequestViewModel(
        int Id,
        string ContractNumber,
        string Title,
        string? Description,
        DateTime StartDate,
        DateTime EndDate,
        decimal ContractValue,
        ContractType ContractType,
        ContractStatus Status,
        int? EmployeeId,
        string? Terms);

    public class UpdateContractRequestViewModelValidator : AbstractValidator<UpdateContractRequestViewModel>
    {
        public UpdateContractRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id is required.");

            RuleFor(x => x.ContractNumber)
                .NotEmpty().WithMessage("Contract Number is required.")
                .MaximumLength(100).WithMessage("Contract Number must be at most 100 chars.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Title must be at least 2 chars.")
                .MaximumLength(200).WithMessage("Title must be at most 200 chars.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must be at most 1000 chars.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start Date is required.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End Date is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End Date must be greater than Start Date.");

            RuleFor(x => x.ContractValue)
                .GreaterThan(0).WithMessage("Contract Value must be greater than 0.");

            RuleFor(x => x.Terms)
                .MaximumLength(2000).WithMessage("Terms must be at most 2000 chars.");
        }
    }
}
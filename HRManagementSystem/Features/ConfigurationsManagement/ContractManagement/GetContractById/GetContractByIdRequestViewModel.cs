using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetContractById
{
    public record GetContractByIdRequestViewModel(Guid Id);

    public class GetContractByIdRequestViewModelValidator : AbstractValidator<GetContractByIdRequestViewModel>
    {
        public GetContractByIdRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}




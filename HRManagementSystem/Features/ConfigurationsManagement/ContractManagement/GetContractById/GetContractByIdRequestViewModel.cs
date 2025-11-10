using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetContractById
{
    public record GetContractByIdRequestViewModel(int Id);

    public class GetContractByIdRequestViewModelValidator : AbstractValidator<GetContractByIdRequestViewModel>
    {
        public GetContractByIdRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}


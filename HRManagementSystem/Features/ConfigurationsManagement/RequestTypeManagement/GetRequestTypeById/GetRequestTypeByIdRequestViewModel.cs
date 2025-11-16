using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.GetRequestTypeById
{
    public record GetRequestTypeByIdRequestViewModel(Guid Id);

    public class GetRequestTypeByIdRequestViewModelValidator : AbstractValidator<GetRequestTypeByIdRequestViewModel>
    {
        public GetRequestTypeByIdRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}




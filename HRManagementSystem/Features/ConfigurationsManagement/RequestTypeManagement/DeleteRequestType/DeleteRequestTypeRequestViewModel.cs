using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.DeleteRequestType
{
    public record DeleteRequestTypeRequestViewModel(Guid Id);

    public class DeleteRequestTypeRequestViewModelValidator : AbstractValidator<DeleteRequestTypeRequestViewModel>
    {
        public DeleteRequestTypeRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}




using FluentValidation;

namespace HRManagementSystem.Features.RequestTypeManagement.DeleteRequestType
{
    public record DeleteRequestTypeRequestViewModel(int Id);

    public class DeleteRequestTypeRequestViewModelValidator : AbstractValidator<DeleteRequestTypeRequestViewModel>
    {
        public DeleteRequestTypeRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}


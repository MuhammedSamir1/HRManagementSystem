using FluentValidation;

namespace HRManagementSystem.Features.RequestTypeManagement.GetRequestTypeById
{
    public record GetRequestTypeByIdRequestViewModel(int Id);

    public class GetRequestTypeByIdRequestViewModelValidator : AbstractValidator<GetRequestTypeByIdRequestViewModel>
    {
        public GetRequestTypeByIdRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}


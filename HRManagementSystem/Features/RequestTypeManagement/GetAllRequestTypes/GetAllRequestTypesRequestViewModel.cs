using FluentValidation;

namespace HRManagementSystem.Features.RequestTypeManagement.GetAllRequestTypes
{
    public record GetAllRequestTypesRequestViewModel();

    public class GetAllRequestTypesRequestViewModelValidator : AbstractValidator<GetAllRequestTypesRequestViewModel>
    {
        public GetAllRequestTypesRequestViewModelValidator()
        {
        }
    }
}


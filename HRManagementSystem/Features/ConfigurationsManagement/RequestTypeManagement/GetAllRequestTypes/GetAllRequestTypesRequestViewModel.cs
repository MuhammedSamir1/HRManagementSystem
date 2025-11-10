using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.GetAllRequestTypes
{
    public record GetAllRequestTypesRequestViewModel();

    public class GetAllRequestTypesRequestViewModelValidator : AbstractValidator<GetAllRequestTypesRequestViewModel>
    {
        public GetAllRequestTypesRequestViewModelValidator()
        {
        }
    }
}


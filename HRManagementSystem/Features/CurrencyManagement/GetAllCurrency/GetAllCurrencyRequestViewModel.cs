using FluentValidation;

namespace HRManagementSystem.Features.CurrencyManagement.GetAllCurrency
{
    public record GetAllCurrencyRequestViewModel();

    public class GetAllCurrencyRequestViewModelValidator : AbstractValidator<GetAllCurrencyRequestViewModel>
    {
        public GetAllCurrencyRequestViewModelValidator()
        {
        }
    }
}

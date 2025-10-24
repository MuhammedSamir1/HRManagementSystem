using FluentValidation;

namespace HRManagementSystem.Features.CurrencyManagement.AddCurrency
{
    public record AddCurrencyRequestViewModel(string Code,
                                           int NumericCode,
                                           string Name,
                                           string Symbol);

    public class AddCurrencyRequestViewModelValidator : AbstractValidator<AddCurrencyRequestViewModel>
    {
        public AddCurrencyRequestViewModelValidator()
        {
        }
    }
}

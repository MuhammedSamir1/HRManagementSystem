namespace HRManagementSystem.Features.CurrencyManagement.GetAllCurrency
{
    public record GetAllCurrencyResponseViewModel(
        string Code,
        int NumericCode,
        string Name,
        string Symbol
        );
}

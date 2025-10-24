namespace HRManagementSystem.Features.CurrencyManagement.GetAllCurrency
{
    public class GetAllCurrencyDto
    {
        public string Code { get; set; } = default!;
        public int NumericCode { get; set; }
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
    }
}

namespace HRManagementSystem.Data.Models
{
    public sealed class Currency : BaseModel<Guid>
    {
        public string Code { get; set; } = default!;
        public int NumericCode { get; set; }
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
    }
}

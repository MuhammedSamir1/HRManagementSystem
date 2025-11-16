namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class EndOfService : BaseModel<Guid>
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime ServiceEndDate { get; set; }
        public int TotalServiceYears { get; set; }
        public int TotalServiceMonths { get; set; }
        public int TotalServiceDays { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}


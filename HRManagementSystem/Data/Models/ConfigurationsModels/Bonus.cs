namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class Bonus : BaseModel<int>
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public BonusType BonusType { get; set; }
        public DateTime BonusDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool IsPaid { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}


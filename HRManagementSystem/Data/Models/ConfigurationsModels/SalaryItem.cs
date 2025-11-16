namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class SalaryItem : BaseModel<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public PayrollItemType ItemType { get; set; } // Addition or Deduction
        public bool IsFixed { get; set; } // Fixed amount or variable
        public bool IsRecurring { get; set; } // Recurring monthly or one-time
    }
}


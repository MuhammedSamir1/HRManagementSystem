namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class Loan : BaseModel<int>
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal MonthlyInstallment { get; set; }
        public int InstallmentMonths { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? StartDeductionDate { get; set; }
        public LoanStatus Status { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}


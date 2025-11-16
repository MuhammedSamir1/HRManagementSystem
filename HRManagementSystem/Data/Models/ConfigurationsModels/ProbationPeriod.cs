namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class ProbationPeriod : BaseModel<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationInDays { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public ProbationPeriodStatus Status { get; set; }
    }
}


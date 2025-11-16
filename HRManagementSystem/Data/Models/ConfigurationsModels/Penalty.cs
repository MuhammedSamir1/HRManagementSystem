namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class Penalty : BaseModel<Guid>
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime PenaltyDate { get; set; }
        public string? Reason { get; set; }
        public PenaltyStatus Status { get; set; }
    }
}


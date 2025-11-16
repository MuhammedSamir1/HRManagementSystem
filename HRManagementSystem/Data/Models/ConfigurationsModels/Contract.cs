namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class Contract : BaseModel<Guid>
    {
        public string ContractNumber { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal ContractValue { get; set; }
        public ContractType ContractType { get; set; }
        public ContractStatus Status { get; set; }
        public string? Terms { get; set; }
    }
}


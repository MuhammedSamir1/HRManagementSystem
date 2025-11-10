using HRManagementSystem.Common.Data.Enums;

namespace HRManagementSystem.Features.ContractManagement.GetContractById
{
    public record GetContractByIdResponseViewModel
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal ContractValue { get; set; }
        public ContractType ContractType { get; set; }
        public ContractStatus Status { get; set; }
        public int? EmployeeId { get; set; }
        public string? Terms { get; set; }
        public bool IsActive { get; set; }
    }
}


namespace HRManagementSystem.Features.BankManagement.GetAllBanks
{
    public record GetAllBanksResponseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Address { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}


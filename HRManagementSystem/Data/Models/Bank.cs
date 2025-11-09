namespace HRManagementSystem.Data.Models
{
    public sealed class Bank : BaseModel<int>
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}


namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public sealed class Bank : BaseModel<Guid>
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}


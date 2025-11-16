namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public sealed class RequestType : BaseModel<Guid>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool RequiresAttachments { get; set; } = false;
    }
}


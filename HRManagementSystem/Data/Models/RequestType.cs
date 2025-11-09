namespace HRManagementSystem.Data.Models
{
    public sealed class RequestType : BaseModel<int>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool RequiresAttachments { get; set; } = false;
    }
}


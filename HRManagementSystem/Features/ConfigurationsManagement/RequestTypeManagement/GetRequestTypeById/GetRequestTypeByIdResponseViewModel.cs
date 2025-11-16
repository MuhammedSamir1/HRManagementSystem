namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.GetRequestTypeById
{
    public record GetRequestTypeByIdResponseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool RequiresAttachments { get; set; }
        public bool IsActive { get; set; }
    }
}



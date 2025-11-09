namespace HRManagementSystem.Features.RequestTypeManagement.GetRequestTypeById
{
    public record GetRequestTypeByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool RequiresAttachments { get; set; }
        public bool IsActive { get; set; }
    }
}


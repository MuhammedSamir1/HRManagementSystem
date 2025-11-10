namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType
{

    // ViewModels for API response
    public sealed record ViewDisabilityTypeViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

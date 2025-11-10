namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType
{
    public sealed record ViewDisabilityTypeDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}

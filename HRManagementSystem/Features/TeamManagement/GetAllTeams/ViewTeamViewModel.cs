namespace HRManagementSystem.Features.TeamManagement.GetAllTeams
{
    public sealed record ViewTeamViewModel
    {
        public Guid Id { get; private set; }
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
        public string? Description { get; init; }
        public Guid DepartmentId { get; init; } = default!;
    }
}


namespace HRManagementSystem.Features.TeamManagement.GetTeamById
{
    public sealed record ViewTeamByIdDto
    {
        public int Id { get; private set; }
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
        public string? Description { get; init; }
        public int DepartmentId { get; init; } = default!;
    }
}

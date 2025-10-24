namespace HRManagementSystem.Features.DepartmentManagement.GetAllDepartments
{
    public class GetAllDepartmentsDto
    {
        public int Id { get; set; }
        public string BranchName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
    }
}

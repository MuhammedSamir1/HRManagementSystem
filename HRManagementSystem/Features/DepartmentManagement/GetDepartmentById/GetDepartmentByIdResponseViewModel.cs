namespace HRManagementSystem.Features.DepartmentManagement.GetDepartmentById
{
    public class GetDepartmentByIdResponseViewModel
    {
        public string Name { get; set; } = default!;
        public string BranchName { get; set; } = null!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
    }
}

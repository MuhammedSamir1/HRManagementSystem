namespace HRManagementSystem.Features.CompanyManagement.GetAllCompanies
{
    public class GetAllCompaniesDto
    {
        public string OrganizationName { get; set; } = null!;
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
    }
}

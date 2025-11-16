namespace HRManagementSystem.Features.CompanyManagement.GetAllCompanies
{
    public class GetAllCompaniesDto
    {
        public Guid Id { get; set; }
        public string OrganizationName { get; set; } = null!;
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
    }
}

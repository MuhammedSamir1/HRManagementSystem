namespace HRManagementSystem.Features.CompanyManagement.GetAllCompanies
{
    public class GetAllCompaniesResponseViewModel
    {
        public Guid Id { get; set; }
        public string OrganizationName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
    }
}


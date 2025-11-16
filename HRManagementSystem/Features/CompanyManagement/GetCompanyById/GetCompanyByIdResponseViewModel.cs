namespace HRManagementSystem.Features.CompanyManagement.GetCompanyById
{
    public class GetCompanyByIdResponseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string OrganizationName { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
    }
}


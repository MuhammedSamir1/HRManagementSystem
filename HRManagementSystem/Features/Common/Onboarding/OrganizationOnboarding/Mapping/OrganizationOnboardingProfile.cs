namespace HRManagementSystem.Features.Common.Onboarding.OrganizationOnboarding.Mapping;

public sealed class OrganizationOnboardingProfile : Profile
{
    public OrganizationOnboardingProfile()
    {
        // المستوى الأعلى
        CreateMap<OrganizationOnboardingRequestViewModel, OrganizationOnboardingDto>();

        // الشركات
        CreateMap<CompanyRequestViewModel, CompanyDto>();

        // الفروع
        CreateMap<BranchRequestViewModel, BranchDto>();

        // الأقسام
        CreateMap<DepartmentRequestViewModel, DepartmentDto>();

        // الفرق
        CreateMap<TeamRequestViewModel, TeamDto>();
    }
}

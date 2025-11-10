using HRManagementSystem.Features.Common.DeleteCascadeGeneric;
using HRManagementSystem.Features.CompanyManagement.DeleteCompany;

namespace HRManagementSystem.Features.CompanyManagement.Mapping;

public sealed class DeleteCompanyCascadeProfile : Profile
{
    public DeleteCompanyCascadeProfile()
    {
        CreateMap<DeleteCompanyRequestViewModel, DeleteEntityCascadeCommand<Company, int>>()
     .ConstructUsing(src => new DeleteEntityCascadeCommand<Company, int>(src.companyId));

    }
}

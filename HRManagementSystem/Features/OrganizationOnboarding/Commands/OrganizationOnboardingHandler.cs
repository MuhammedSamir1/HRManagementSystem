using HRManagementSystem.Features.BranchManagement.AddBranch.Commands;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.Dtos;
using HRManagementSystem.Features.CompanyManagement.AddCompany.Commands;
using HRManagementSystem.Features.DepartmentManagement.AddDepartment.Commands;
using HRManagementSystem.Features.OrganizationManagement.AddOrganization.Commands;
using HRManagementSystem.Features.TeamManagement.AddTeam.Commands;

namespace HRManagementSystem.Features.OrganizationOnboarding.Commands
{
    public sealed class OrganizationOnboardingHandler
        : RequestHandlerBase<OrganizationOnboardingCommand, RequestResult<ViewOrganizationOnboardingDto>, Organization, int>
    {
        public OrganizationOnboardingHandler(RequestHandlerBaseParameters<Organization, int> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<ViewOrganizationOnboardingDto>> Handle(OrganizationOnboardingCommand request, CancellationToken ct)
        {
            #region 1. Add Organization
            var address = _mapper.Map<AddOrganizationAddressDto>(request.OnboardingDto.Address);
            var currency = _mapper.Map<AddOrganizationCurrencyDto>(request.OnboardingDto.Currency);

            var resultOrganization = await _mediator.Send(
                new AddOrganizationCommand(
                    request.OnboardingDto.Name,
                    request.OnboardingDto.LegalName,
                    request.OnboardingDto.Industry,
                    request.OnboardingDto.Description,
                    request.OnboardingDto.DefaultTimezone,
                    currency,
                    address
                ), ct);

            if (!resultOrganization.isSuccess)
                return RequestResult<ViewOrganizationOnboardingDto>.Failure(
                    resultOrganization.message, resultOrganization.errorCode);

            var orgId = resultOrganization.data.Id;
            var view = new ViewOrganizationOnboardingDto { OrganizationId = orgId };
            #endregion

            #region 2. Loop through Companies
            foreach (var companyDto in request.OnboardingDto.Companies ?? new List<CompanyDto>())
            {
                var companyAdded = await _mediator.Send(
                    new AddCompanyCommand(
                        orgId,
                        companyDto.Name,
                        companyDto.Code,
                        companyDto.Description
                    ), ct);

                if (!companyAdded.isSuccess)
                    return RequestResult<ViewOrganizationOnboardingDto>.Failure(
                        companyAdded.message, companyAdded.errorCode);

                var companyId = companyAdded.data.Id;
                var companyNode = new CompanyNodeDto { CompanyId = companyId };
                view.Companies.Add(companyNode);

                #region 3. Loop through Branches
                foreach (var branchDto in companyDto.Branches ?? new List<BranchDto>())
                {
                    var branchAddress = _mapper.Map<AddBranchAddressDto>(branchDto.Address);

                    var branchAdded = await _mediator.Send(
                        new AddBranchCommand(
                            branchDto.Name,
                            branchDto.Description,
                            companyId, 
                            branchDto.Code,
                            branchAddress
                        ), ct);

                    if (!branchAdded.isSuccess)
                        return RequestResult<ViewOrganizationOnboardingDto>.Failure(
                            branchAdded.message, branchAdded.errorCode);

                    var branchId = branchAdded.data.Id;
                    var branchNode = new BranchNodeDto { BranchId = branchId };
                    companyNode.Branches.Add(branchNode);

                    #region 4. Loop through Departments
                    foreach (var deptDto in branchDto.Departments ?? new List<DepartmentDto>())
                    {
                        var deptAdded = await _mediator.Send(
                            new AddDepartmentCommand(
                                branchId, 
                                deptDto.Name,
                                deptDto.Code,
                                deptDto.Description
                            ), ct);

                        if (!deptAdded.isSuccess)
                            return RequestResult<ViewOrganizationOnboardingDto>.Failure(
                                deptAdded.message, deptAdded.errorCode);

                        var deptId = deptAdded.data.Id;
                        var deptNode = new DepartmentNodeDto { DepartmentId = deptId };
                        branchNode.Departments.Add(deptNode);

                        #region 5. Loop through Teams
                        foreach (var teamDto in deptDto.Teams ?? new List<TeamDto>())
                        {
                            var teamAdded = await _mediator.Send(
                                new AddTeamCommand(
                                    teamDto.Name,
                                    teamDto.Code,
                                    teamDto.Description,
                                    deptId 
                                ), ct);

                            if (!teamAdded.isSuccess)
                                return RequestResult<ViewOrganizationOnboardingDto>.Failure(
                                    teamAdded.message, teamAdded.errorCode);

                            var teamId = teamAdded.data.Id;
                            deptNode.Teams.Add(new TeamNodeDto { TeamId = teamId });
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
            }
            #endregion

            return RequestResult<ViewOrganizationOnboardingDto>.Success(
                view, "Organization onboarding completed successfully!");
        }
    }
}

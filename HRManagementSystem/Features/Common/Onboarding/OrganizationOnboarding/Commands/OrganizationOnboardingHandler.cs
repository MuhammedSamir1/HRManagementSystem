using HRManagementSystem.Features.BranchManagement.AddBranch.Commands;
using HRManagementSystem.Features.CompanyManagement.AddCompany.Commands;
using HRManagementSystem.Features.DepartmentManagement.AddDepartment.Commands;
using HRManagementSystem.Features.OrganizationManagement.AddOrginzation.Commands;
using HRManagementSystem.Features.ScopeManagement.EnsureScope.Commands;
using HRManagementSystem.Features.TeamManagement.AddTeam.Commands;

namespace HRManagementSystem.Features.Common.Onboarding.OrganizationOnboarding.Commands
{
    public sealed class OrganizationOnboardingHandler
        : RequestHandlerBase<OrganizationOnboardingCommand, RequestResult<ViewOrganizationOnboardingDto>, Organization, Guid>
    {
        public OrganizationOnboardingHandler(RequestHandlerBaseParameters<Organization, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<ViewOrganizationOnboardingDto>> Handle(OrganizationOnboardingCommand request, CancellationToken ct)
        {
            // Validation is handled by OrganizationOnboardingRequestValidator in the endpoint
            // Currency and Address are already validated before reaching this handler

            #region 1. Add Organization
            var resultOrganization = await _mediator.Send(
                new AddOrganizationCommand(
                    request.OnboardingDto.Name,
                    request.OnboardingDto.LegalName,
                    request.OnboardingDto.Industry,
                    request.OnboardingDto.Description,
                    request.OnboardingDto.DefaultTimezone,
                    request.OnboardingDto.Currency,
                    request.OnboardingDto.Address
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
                // REMOVED: Company scope call - only create scope for complete hierarchy paths (Org → Company → Branch → Dept → Team)
                var companyNode = new CompanyNodeDto { CompanyId = companyId, ScopeId = Guid.Empty };
                view.Companies.Add(companyNode);

                #region 3. Loop through Branches
                foreach (var branchDto in companyDto.Branches ?? new List<BranchDto>())
                {
                    var branchAdded = await _mediator.Send(
                        new AddBranchCommand(
                            branchDto.Name,
                            branchDto.Description,
                            companyId,
                            branchDto.Code,
                            branchDto.Address
                        ), ct);

                    if (!branchAdded.isSuccess)
                        return RequestResult<ViewOrganizationOnboardingDto>.Failure(
                            branchAdded.message, branchAdded.errorCode);

                    var branchId = branchAdded.data.Id;
                    // REMOVED: Branch scope call - only create scope for complete hierarchy paths (Org → Company → Branch → Dept → Team)
                    var branchNode = new BranchNodeDto { BranchId = branchId, ScopeId = Guid.Empty };
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
                        // REMOVED: Department scope call - only create scope for complete hierarchy paths (Org → Company → Branch → Dept → Team)
                        var deptNode = new DepartmentNodeDto { DepartmentId = deptId, ScopeId = Guid.Empty };
                        branchNode.Departments.Add(deptNode);

                        #region 5. Loop through Teams - ONLY CREATE SCOPE HERE (Complete Hierarchy)
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

                            // ONLY CREATE SCOPE FOR COMPLETE HIERARCHY PATHS (Org → Company → Branch → Dept → Team)
                            var teamScopeResult = await _mediator.Send(
                                new EnsureScopeCommand(orgId, companyId, branchId, deptId, teamId), ct);

                            if (!teamScopeResult.isSuccess)
                                return RequestResult<ViewOrganizationOnboardingDto>.Failure(
                                    teamScopeResult.message, teamScopeResult.errorCode);

                            deptNode.Teams.Add(new TeamNodeDto { TeamId = teamId, ScopeId = teamScopeResult.data });

                            // Update parent nodes with the scope ID from the first team (for reference)
                            // This ensures parent nodes have a scope ID if needed, but scope is only created for complete paths
                            if (deptNode.ScopeId == Guid.Empty)
                                deptNode.ScopeId = teamScopeResult.data;
                            if (branchNode.ScopeId == Guid.Empty)
                                branchNode.ScopeId = teamScopeResult.data;
                            if (companyNode.ScopeId == Guid.Empty)
                                companyNode.ScopeId = teamScopeResult.data;
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


using HRManagementSystem.Features.BranchManagement.DeleteBranch.Commands;
using HRManagementSystem.Features.Common.DeleteEntityCascade.Command;
using HRManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
using HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands;
using HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Commands;
using HRManagementSystem.Features.TeamManagement.DeleteTeam.Commands;

namespace HRManagementSystem.Features.Common.DeleteEntityCascade.Handler
{
    public class DeleteEntityCascadeCommandHandler<TEntity, TKey>
        : RequestHandlerBase<DeleteEntityCascadeCommand<TEntity, TKey>, RequestResult<bool>, TEntity, TKey>
        where TEntity : BaseModel<TKey>
    {

        public DeleteEntityCascadeCommandHandler(
            RequestHandlerBaseParameters<TEntity, TKey> parameters
        ) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(DeleteEntityCascadeCommand<TEntity, TKey> request, CancellationToken ct)
        {
            var ok = await DeleteCascadeAsync(typeof(TEntity), request.Id, ct);
            return ok
                ? RequestResult<bool>.Success(true)
                : RequestResult<bool>.Failure(ErrorCode.NotFound);
        }

        #region Core
        private async Task<bool> DeleteCascadeAsync(Type rootType, Guid id, CancellationToken ct)
        {
            if (rootType == typeof(Organization))
            {
                // Organization -> Companies
                var companyIds = await _generalRepo.GetIdsAsync<Company, Guid>(x => x.OrganizationId == id && !x.IsDeleted, ct);
                foreach (var cid in companyIds)
                    if (!await DeleteCascadeAsync(typeof(Company), cid, ct)) return false;

                var res = await _mediator.Send(new DeleteOrganizationCommand(id), ct);
                return res.isSuccess;
            }

            if (rootType == typeof(Company))
            {
                // Company -> Branches
                var branchIds = await _generalRepo.GetIdsAsync<Branch, Guid>(b => b.CompanyId == id && !b.IsDeleted, ct);
                foreach (var branchId in branchIds)
                    if (!await DeleteCascadeAsync(typeof(Branch), branchId, ct)) return false;

                var res = await _mediator.Send(new DeleteCompanyCommand(id), ct);
                return res.isSuccess;
            }

            if (rootType == typeof(Branch))
            {
                // Branch -> Departments
                var departmentIds = await _generalRepo.GetIdsAsync<Department, Guid>(d => d.BranchId == id && !d.IsDeleted, ct);
                foreach (var departmentId in departmentIds)
                    if (!await DeleteCascadeAsync(typeof(Department), departmentId, ct)) return false;

                var res = await _mediator.Send(new DeleteBranchCommand(id), ct);
                return res.isSuccess;
            }

            if (rootType == typeof(Department))
            {
                // Department -> Teams (Leaf)
                var teamIds = await _generalRepo.GetIdsAsync<Team, Guid>(t => t.DepartmentId == id && !t.IsDeleted, ct);
                foreach (var teamId in teamIds)
                    if (!await DeleteCascadeAsync(typeof(Team), teamId, ct)) return false;

                var res = await _mediator.Send(new DeleteDepartmentCommand(id), ct);
                return res.isSuccess;
            }

            if (rootType == typeof(Team))
            {
                var res = await _mediator.Send(new DeleteTeamCommand(id), ct);
                return res.isSuccess;
            }

            return false;
        }
        #endregion
    }
}


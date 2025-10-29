using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Features.TeamManagement.HasAssignedTeams;
using MediatR;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands
{
    public record DeleteDepartmentCommand(int departmentId) : IRequest<RequestResult<bool>>;


    public sealed class DeleteDepartmentCommandHandler : RequestHandlerBase<DeleteDepartmentCommand, RequestResult<bool>, Department, int>
    {
        public DeleteDepartmentCommandHandler(RequestHandlerBaseParameters<Department, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteDepartmentCommand request, CancellationToken ct)
        {
            // 1. القاعدة 3-1: التحقق من وجود الكيان (Existence Check)
            var existingDepartment = await _generalRepo.GetByIdWithTracking(request.departmentId);
            if (existingDepartment == null)
            {
                return RequestResult<bool>.Failure("Department not found or already deleted.", ErrorCode.NotFound);
            }

            // 2. القاعدة 3-2: التحقق من التبعيات (Teams)
            var teamCheck = await _mediator.Send(new HasAssignedTeamsQuery(request.departmentId), ct);
            if (!teamCheck.isSuccess)
            {
             
                return RequestResult<bool>.Failure(teamCheck.message, teamCheck.errorCode);
            }

            
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.departmentId, ct);

            if (!isDeleted)
            {
                return RequestResult<bool>.Failure("Failed to delete the department.", ErrorCode.InternalServerError);
            }

            return RequestResult<bool>.Success(true, "Department deleted successfully!");
        }
    }
}

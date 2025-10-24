using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands
{
    public record DeleteDepartmentCommand(int departmentId) : IRequest<RequestResult<bool>>;

    public sealed class DeleteDepartmentCommandHandler : RequestHandlerBase<DeleteDepartmentCommand,
    RequestResult<bool>, Department, int>
    {
        public DeleteDepartmentCommandHandler(RequestHandlerBaseParameters<Department, int> parameters) : base(parameters)
        { }

        public override async Task<RequestResult<bool>> Handle(DeleteDepartmentCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.departmentId, ct);

            if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.OrganizationNotFound);
            return RequestResult<bool>.Success(isDeleted);
        }
    }
}

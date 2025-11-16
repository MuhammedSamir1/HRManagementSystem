namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands;

public sealed class DeleteDepartmentCommandHandler : RequestHandlerBase<DeleteDepartmentCommand,
   RequestResult<bool>, Department, Guid>
{
    public DeleteDepartmentCommandHandler(RequestHandlerBaseParameters<Department, Guid> parameters) : base(parameters)
    { }

    public override async Task<RequestResult<bool>> Handle(DeleteDepartmentCommand request, CancellationToken ct)
    {
        var isDeleted = await _generalRepo.SoftDeleteAsync(request.departmentId, ct);

        if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.DepartmentNotFound);
        return RequestResult<bool>.Success(isDeleted);
    }
}

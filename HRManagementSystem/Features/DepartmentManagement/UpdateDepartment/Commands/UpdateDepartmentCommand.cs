using HRManagementSystem.Features.Common.BranchCommon.Queries;
using HRManagementSystem.Features.Common.DepartmentCommon.Queries;

namespace HRManagementSystem.Features.DepartmentManagement.UpdateDepartment.Commands
{
    public record UpdateDepartmentCommand(
     int Id,
     int branchId,
     string name,
     string code,
     string? description)
     : IRequest<RequestResult<bool>>;
    public sealed class UpdateDepartmentCommandHandler : RequestHandlerBase<UpdateDepartmentCommand, RequestResult<bool>, Department, int>
    {
        public UpdateDepartmentCommandHandler(RequestHandlerBaseParameters<Department, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(UpdateDepartmentCommand request, CancellationToken ct)
        {

            var existingDepartment = await _generalRepo.GetByIdWithTracking(request.Id);
            if (existingDepartment == null)
            {
                return RequestResult<bool>.Failure("Department not found or already deleted.", ErrorCode.NotFound);
            }


            if (existingDepartment.Code != request.code)
            {
                return RequestResult<bool>.Failure("Department Code is immutable and cannot be changed after creation.", ErrorCode.Forbidden);
            }


            if (existingDepartment.BranchId != request.branchId)
            {

                var branchValidation = await _mediator.Send(new IsBranchValidQuery(request.branchId), ct);
                if (!branchValidation.isSuccess)
                {

                    return RequestResult<bool>.Failure(branchValidation.message, branchValidation.errorCode);
                }


                var uniqueValidation = await _mediator.Send(
                    new IsDepartmentCodeUniqueForUpdateQuery(request.Id, request.branchId, request.code), ct);

                if (!uniqueValidation.isSuccess)
                {

                    return RequestResult<bool>.Failure(uniqueValidation.message, uniqueValidation.errorCode);
                }
            }

            _mapper.Map(request, existingDepartment);


            var isUpdated = await _generalRepo.UpdateAsync(existingDepartment, ct);

            if (!isUpdated)
            {
                return RequestResult<bool>.Failure("Failed to save department changes to the database.", ErrorCode.InternalServerError);
            }

            return RequestResult<bool>.Success(true, "Department updated successfully!");
        }
    }
}

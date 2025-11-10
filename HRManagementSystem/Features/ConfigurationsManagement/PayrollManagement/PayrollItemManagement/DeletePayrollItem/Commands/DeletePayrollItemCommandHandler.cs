using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.Common.Queries;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.DeletePayrollItem.Commands;

namespace HRManagementSystem.Features.Configurations.PayrollManagement.PayrollItemManagement.DeletePayrollItem.Commands
{
    public sealed class DeletePayrollItemCommandHandler :
    RequestHandlerBase<DeletePayrollItemCommand, RequestResult<bool>, PayrollItem, int>
    {



        public DeletePayrollItemCommandHandler(
            RequestHandlerBaseParameters<PayrollItem, int> parameters) : base(parameters)
        {

        }

        public override async Task<RequestResult<bool>> Handle(DeletePayrollItemCommand request, CancellationToken cancellationToken)
        {
            var existingItem = await _generalRepo.GetByIdAsync(request.Id);

            if (existingItem == null || existingItem.IsDeleted)
            {
                return RequestResult<bool>.Failure("Payroll Item not found or already deleted.", ErrorCode.NotFound);
            }


            if (existingItem.IsStatutory)
            {
                return RequestResult<bool>.Failure("Cannot delete a statutory (legal/mandatory) payroll item.", ErrorCode.Conflict);
            }


            var assignmentCheck = await _mediator.Send(new HasPayrollItemAssignmentsQuery(request.Id), cancellationToken);


            if (assignmentCheck.isSuccess && assignmentCheck.data)
            {
                return RequestResult<bool>.Failure(
                    "Cannot delete item because it's currently assigned to active employees.",
                    ErrorCode.Conflict);
            }

            if (!assignmentCheck.isSuccess && assignmentCheck.errorCode != ErrorCode.NotFound)
            {
                return RequestResult<bool>.Failure(assignmentCheck.message, assignmentCheck.errorCode);
            }


            var result = await _generalRepo.SoftDeleteAsync(request.Id, cancellationToken);

            if (!result)
            {
                return RequestResult<bool>.Failure("Failed to delete the payroll item.", ErrorCode.InternalServerError);
            }

            return RequestResult<bool>.Success(true, "Payroll Item deleted successfully.");
        }
    }
}

using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.DeleteSalaryItem.Commands
{
    public sealed record DeleteSalaryItemCommand(int Id) : IRequest<RequestResult<bool>>;

    public class DeleteSalaryItemCommandHandler : RequestHandlerBase<DeleteSalaryItemCommand, RequestResult<bool>, SalaryItem, int>
    {
        public DeleteSalaryItemCommandHandler(RequestHandlerBaseParameters<SalaryItem, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteSalaryItemCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted)
                return RequestResult<bool>.Failure("Salary Item not found or wasn't deleted successfully!", ErrorCode.NotFound);

            return RequestResult<bool>.Success(true, "Salary Item deleted successfully!");
        }
    }
}

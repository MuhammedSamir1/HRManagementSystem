using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.DeleteSalaryItem.Commands
{
    public sealed record DeleteSalaryItemCommand(int Id) : IRequest<RequestResult<string>>;

    public class DeleteSalaryItemCommandHandler : RequestHandlerBase<DeleteSalaryItemCommand, RequestResult<string>, SalaryItem, int>
    {
        public DeleteSalaryItemCommandHandler(RequestHandlerBaseParameters<SalaryItem, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<string>> Handle(DeleteSalaryItemCommand request, CancellationToken ct)
        {
            var salaryItem = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (salaryItem == null)
                return RequestResult<string>.Failure("Salary Item not found.", ErrorCode.NotFound);

            var isDeleted = await _generalRepo.DeleteAsync(salaryItem, ct);

            if (!isDeleted)
                return RequestResult<string>.Failure("Salary Item wasn't deleted successfully!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success("Salary Item deleted successfully!");
        }
    }
}

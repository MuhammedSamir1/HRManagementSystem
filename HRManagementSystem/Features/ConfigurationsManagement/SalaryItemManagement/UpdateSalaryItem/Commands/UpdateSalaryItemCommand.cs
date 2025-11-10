using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.UpdateSalaryItem.Commands
{
    public sealed record UpdateSalaryItemCommand(
        int Id,
        string Name,
        string? Description,
        decimal Amount,
        PayrollItemType ItemType,
        bool IsFixed,
        bool IsRecurring,
        int? EmployeeId)
        : IRequest<RequestResult<string>>;

    public class UpdateSalaryItemCommandHandler : RequestHandlerBase<UpdateSalaryItemCommand, RequestResult<string>, SalaryItem, int>
    {
        public UpdateSalaryItemCommandHandler(RequestHandlerBaseParameters<SalaryItem, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<string>> Handle(UpdateSalaryItemCommand request, CancellationToken ct)
        {
            var salaryItem = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (salaryItem == null)
                return RequestResult<string>.Failure("Salary Item not found.", ErrorCode.NotFound);

            var nameExists = await _generalRepo.CheckAnyAsync(x => x.Name == request.Name && x.Id != request.Id, ct);
            if (nameExists)
                return RequestResult<string>.Failure("Salary Item Name already exists.", ErrorCode.Conflict);

            _mapper.Map(request, salaryItem);

            var isUpdated = await _generalRepo.UpdateAsync(salaryItem, ct);

            if (!isUpdated)
                return RequestResult<string>.Failure("Salary Item wasn't updated successfully!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success("Salary Item updated successfully!");
        }
    }
}

using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

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
        : IRequest<RequestResult<bool>>;

    public class UpdateSalaryItemCommandHandler : RequestHandlerBase<UpdateSalaryItemCommand, RequestResult<bool>, SalaryItem, int>
    {
        public UpdateSalaryItemCommandHandler(RequestHandlerBaseParameters<SalaryItem, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(UpdateSalaryItemCommand request, CancellationToken ct)
        {
            var salaryItem = await _generalRepo.GetByIdWithTracking(request.Id);

            if (salaryItem == null || salaryItem.IsDeleted)
                return RequestResult<bool>.Failure("Salary Item not found.", ErrorCode.NotFound);

            var nameExists = await _generalRepo.Get(x => x.Name == request.Name && x.Id != request.Id && !x.IsDeleted, ct).AnyAsync(ct);
            if (nameExists)
                return RequestResult<bool>.Failure("Salary Item Name already exists.", ErrorCode.Conflict);

            salaryItem.Name = request.Name;
            salaryItem.Description = request.Description;
            salaryItem.Amount = request.Amount;
            salaryItem.ItemType = request.ItemType;
            salaryItem.IsFixed = request.IsFixed;
            salaryItem.IsRecurring = request.IsRecurring;
            salaryItem.EmployeeId = request.EmployeeId;

            await _generalRepo.UpdateAsync(salaryItem, ct);

            return RequestResult<bool>.Success(true, "Salary Item updated successfully!");
        }
    }
}

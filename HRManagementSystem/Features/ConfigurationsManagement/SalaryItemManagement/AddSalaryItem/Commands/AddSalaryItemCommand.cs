using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.AddSalaryItem.Commands
{
    public sealed record AddSalaryItemCommand(
        string Name,
        string? Description,
        decimal Amount,
        PayrollItemType ItemType,
        bool IsFixed,
        bool IsRecurring,
        int? EmployeeId)
        : IRequest<RequestResult<int>>;

    public class AddSalaryItemCommandHandler : RequestHandlerBase<AddSalaryItemCommand, RequestResult<int>, SalaryItem, int>
    {
        public AddSalaryItemCommandHandler(RequestHandlerBaseParameters<SalaryItem, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<int>> Handle(AddSalaryItemCommand request, CancellationToken ct)
        {
            var nameExists = await _generalRepo.Get(x => x.Name == request.Name && !x.IsDeleted, ct).AnyAsync(ct);
            if (nameExists)
                return RequestResult<int>.Failure("Salary Item Name already exists.", ErrorCode.Conflict);

            var salaryItem = _mapper.Map<SalaryItem>(request);

            var isAdded = await _generalRepo.AddAsync(salaryItem, ct);

            if (!isAdded) 
                return RequestResult<int>.Failure("Salary Item wasn't added successfully!", ErrorCode.InternalServerError);

            return RequestResult<int>.Success(salaryItem.Id, "Salary Item added successfully!");
        }
    }
}

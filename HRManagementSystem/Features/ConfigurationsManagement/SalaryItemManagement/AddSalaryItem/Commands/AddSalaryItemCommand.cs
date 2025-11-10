using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;

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
        : IRequest<RequestResult<CreatedIdDto>>;

    public class AddSalaryItemCommandHandler : RequestHandlerBase<AddSalaryItemCommand, RequestResult<CreatedIdDto>, SalaryItem, int>
    {
        public AddSalaryItemCommandHandler(RequestHandlerBaseParameters<SalaryItem, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddSalaryItemCommand request, CancellationToken ct)
        {
            var salaryItem = _mapper.Map<AddSalaryItemCommand, SalaryItem>(request);

            var nameExists = await _generalRepo.CheckAnyAsync(x => x.Name == request.Name, ct);
            if (nameExists)
                return RequestResult<CreatedIdDto>.Failure("Salary Item Name already exists.", ErrorCode.Conflict);

            var isAdded = await _generalRepo.AddAsync(salaryItem, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Salary Item wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(salaryItem);
            return RequestResult<CreatedIdDto>.Success(mapped, "Salary Item added successfully!");
        }
    }
}

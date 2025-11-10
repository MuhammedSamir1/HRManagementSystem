using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.AddEndOfService.Commands
{
    public sealed record AddEndOfServiceCommand(
        string Title,
        string? Description,
        decimal Amount,
        DateTime ServiceStartDate,
        DateTime ServiceEndDate,
        int TotalServiceYears,
        int TotalServiceMonths,
        int TotalServiceDays,
        DateTime? PaymentDate,
        int? EmployeeId)
        : IRequest<RequestResult<CreatedIdDto>>;

    public class AddEndOfServiceCommandHandler : RequestHandlerBase<AddEndOfServiceCommand, RequestResult<CreatedIdDto>, EndOfService, int>
    {
        public AddEndOfServiceCommandHandler(RequestHandlerBaseParameters<EndOfService, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddEndOfServiceCommand request, CancellationToken ct)
        {
            var endOfService = _mapper.Map<AddEndOfServiceCommand, EndOfService>(request);

            var isAdded = await _generalRepo.AddAsync(endOfService, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("End Of Service wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(endOfService);
            return RequestResult<CreatedIdDto>.Success(mapped, "End Of Service added successfully!");
        }
    }
}


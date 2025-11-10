using HRManagementSystem.Data.Models.ConfigurationsModels;

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
        : IRequest<RequestResult<int>>;

    public class AddEndOfServiceCommandHandler : RequestHandlerBase<AddEndOfServiceCommand, RequestResult<int>, EndOfService, int>
    {
        public AddEndOfServiceCommandHandler(RequestHandlerBaseParameters<EndOfService, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<int>> Handle(AddEndOfServiceCommand request, CancellationToken ct)
        {
            var endOfService = _mapper.Map<EndOfService>(request);

            var isAdded = await _generalRepo.AddAsync(endOfService, ct);

            if (!isAdded) 
                return RequestResult<int>.Failure("End Of Service wasn't added successfully!", ErrorCode.InternalServerError);

            return RequestResult<int>.Success(endOfService.Id, "End Of Service added successfully!");
        }
    }
}

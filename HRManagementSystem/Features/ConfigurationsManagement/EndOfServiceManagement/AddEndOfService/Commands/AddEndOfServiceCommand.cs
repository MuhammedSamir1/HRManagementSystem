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
        DateTime? PaymentDate)
        : IRequest<RequestResult<Guid>>;

    public class AddEndOfServiceCommandHandler : RequestHandlerBase<AddEndOfServiceCommand, RequestResult<Guid>, EndOfService, Guid>
    {
        public AddEndOfServiceCommandHandler(RequestHandlerBaseParameters<EndOfService, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<Guid>> Handle(AddEndOfServiceCommand request, CancellationToken ct)
        {
            var endOfService = _mapper.Map<EndOfService>(request);

            var isAdded = await _generalRepo.AddAsync(endOfService, ct);

            if (!isAdded)
                return RequestResult<Guid>.Failure("End Of Service wasn't added successfully!", ErrorCode.InternalServerError);

            return RequestResult<Guid>.Success(endOfService.Id, "End Of Service added successfully!");
        }
    }
}


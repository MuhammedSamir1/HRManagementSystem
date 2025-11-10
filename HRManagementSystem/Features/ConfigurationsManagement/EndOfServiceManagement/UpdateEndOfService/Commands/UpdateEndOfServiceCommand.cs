using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.UpdateEndOfService.Commands
{
    public sealed record UpdateEndOfServiceCommand(
        int Id,
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
        : IRequest<RequestResult<string>>;

    public class UpdateEndOfServiceCommandHandler : RequestHandlerBase<UpdateEndOfServiceCommand, RequestResult<string>, EndOfService, int>
    {
        public UpdateEndOfServiceCommandHandler(RequestHandlerBaseParameters<EndOfService, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<string>> Handle(UpdateEndOfServiceCommand request, CancellationToken ct)
        {
            var endOfService = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (endOfService == null)
                return RequestResult<string>.Failure("End Of Service not found.", ErrorCode.NotFound);

            _mapper.Map(request, endOfService);

            var isUpdated = await _generalRepo.UpdateAsync(endOfService, ct);

            if (!isUpdated)
                return RequestResult<string>.Failure("End Of Service wasn't updated successfully!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success("End Of Service updated successfully!");
        }
    }
}

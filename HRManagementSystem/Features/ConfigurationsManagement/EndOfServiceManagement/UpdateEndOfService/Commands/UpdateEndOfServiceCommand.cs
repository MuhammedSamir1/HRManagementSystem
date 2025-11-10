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
        : IRequest<RequestResult<bool>>;

    public class UpdateEndOfServiceCommandHandler : RequestHandlerBase<UpdateEndOfServiceCommand, RequestResult<bool>, EndOfService, int>
    {
        public UpdateEndOfServiceCommandHandler(RequestHandlerBaseParameters<EndOfService, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(UpdateEndOfServiceCommand request, CancellationToken ct)
        {
            var endOfService = await _generalRepo.GetByIdWithTracking(request.Id);

            if (endOfService == null || endOfService.IsDeleted)
                return RequestResult<bool>.Failure("End Of Service not found.", ErrorCode.NotFound);

            endOfService.Title = request.Title;
            endOfService.Description = request.Description;
            endOfService.Amount = request.Amount;
            endOfService.ServiceStartDate = request.ServiceStartDate;
            endOfService.ServiceEndDate = request.ServiceEndDate;
            endOfService.TotalServiceYears = request.TotalServiceYears;
            endOfService.TotalServiceMonths = request.TotalServiceMonths;
            endOfService.TotalServiceDays = request.TotalServiceDays;
            endOfService.PaymentDate = request.PaymentDate;
            endOfService.EmployeeId = request.EmployeeId;

            await _generalRepo.UpdateAsync(endOfService, ct);

            return RequestResult<bool>.Success(true, "End Of Service updated successfully!");
        }
    }
}

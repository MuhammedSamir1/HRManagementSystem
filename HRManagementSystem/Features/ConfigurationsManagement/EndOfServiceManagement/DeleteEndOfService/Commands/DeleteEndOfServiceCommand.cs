using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.DeleteEndOfService.Commands
{
    public sealed record DeleteEndOfServiceCommand(int Id) : IRequest<RequestResult<bool>>;

    public class DeleteEndOfServiceCommandHandler : RequestHandlerBase<DeleteEndOfServiceCommand, RequestResult<bool>, EndOfService, int>
    {
        public DeleteEndOfServiceCommandHandler(RequestHandlerBaseParameters<EndOfService, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteEndOfServiceCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted)
                return RequestResult<bool>.Failure("End Of Service not found or wasn't deleted successfully!", ErrorCode.NotFound);

            return RequestResult<bool>.Success(true, "End Of Service deleted successfully!");
        }
    }
}

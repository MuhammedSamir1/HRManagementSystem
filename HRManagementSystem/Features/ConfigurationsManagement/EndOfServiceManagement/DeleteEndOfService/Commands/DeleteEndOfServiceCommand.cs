using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.DeleteEndOfService.Commands
{
    public sealed record DeleteEndOfServiceCommand(int Id) : IRequest<RequestResult<string>>;

    public class DeleteEndOfServiceCommandHandler : RequestHandlerBase<DeleteEndOfServiceCommand, RequestResult<string>, EndOfService, int>
    {
        public DeleteEndOfServiceCommandHandler(RequestHandlerBaseParameters<EndOfService, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<string>> Handle(DeleteEndOfServiceCommand request, CancellationToken ct)
        {
            var endOfService = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (endOfService == null)
                return RequestResult<string>.Failure("End Of Service not found.", ErrorCode.NotFound);

            var isDeleted = await _generalRepo.DeleteAsync(endOfService, ct);

            if (!isDeleted)
                return RequestResult<string>.Failure("End Of Service wasn't deleted successfully!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success("End Of Service deleted successfully!");
        }
    }
}

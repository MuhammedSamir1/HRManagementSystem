using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.DeleteRequestType.Commands
{
    public record DeleteRequestTypeCommand(int Id) : IRequest<RequestResult<bool>>;

    public class DeleteRequestTypeCommandHandler : RequestHandlerBase<DeleteRequestTypeCommand, RequestResult<bool>, RequestType, int>
    {
        public DeleteRequestTypeCommandHandler(RequestHandlerBaseParameters<RequestType, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteRequestTypeCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted) return RequestResult<bool>.Failure("RequestType not found.", ErrorCode.NotFound);

            return RequestResult<bool>.Success(isDeleted, "RequestType deleted successfully!");
        }
    }
}


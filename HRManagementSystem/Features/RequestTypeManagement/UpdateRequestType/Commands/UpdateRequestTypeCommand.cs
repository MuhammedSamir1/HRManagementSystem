namespace HRManagementSystem.Features.RequestTypeManagement.UpdateRequestType.Commands
{
    public record UpdateRequestTypeCommand(int Id, string Name, string? Description, bool RequiresAttachments) : IRequest<RequestResult<bool>>;

    public class UpdateRequestTypeCommandHandler : RequestHandlerBase<UpdateRequestTypeCommand, RequestResult<bool>, RequestType, int>
    {
        public UpdateRequestTypeCommandHandler(RequestHandlerBaseParameters<RequestType, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(UpdateRequestTypeCommand request, CancellationToken ct)
        {
            var requestType = await _generalRepo.GetByIdAsync(request.Id);

            if (requestType == null)
                return RequestResult<bool>.Failure("RequestType not found.", ErrorCode.NotFound);

            _mapper.Map(request, requestType);

            var isUpdated = await _generalRepo.UpdateAsync(requestType, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("RequestType wasn't updated successfully!", ErrorCode.InternalServerError);

            return RequestResult<bool>.Success(isUpdated, "RequestType updated successfully!");
        }
    }
}


using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.RequestTypeManagement.AddRequestType.Commands
{
    public record AddRequestTypeCommand(string Name, string? Description, bool RequiresAttachments) : IRequest<RequestResult<CreatedIdDto>>;

    public class AddRequestTypeCommandHandler : RequestHandlerBase<AddRequestTypeCommand, RequestResult<CreatedIdDto>, RequestType, int>
    {
        public AddRequestTypeCommandHandler(RequestHandlerBaseParameters<RequestType, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddRequestTypeCommand request, CancellationToken ct)
        {
            var requestType = _mapper.Map<AddRequestTypeCommand, RequestType>(request);

            var nameExists = await _generalRepo.ExistsByNameAsync<RequestType>(request.Name);
            if (nameExists)
                return RequestResult<CreatedIdDto>.Failure("RequestType Name already exists.", ErrorCode.Conflict);

            var isAdded = await _generalRepo.AddAsync(requestType, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("RequestType wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(requestType);
            return RequestResult<CreatedIdDto>.Success(mapped, "RequestType added successfully!");
        }
    }
}


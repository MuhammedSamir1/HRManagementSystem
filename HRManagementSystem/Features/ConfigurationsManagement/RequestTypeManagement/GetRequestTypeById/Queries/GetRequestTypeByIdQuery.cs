using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.GetRequestTypeById.Queries
{
    public record GetRequestTypeByIdQuery(Guid Id) : IRequest<RequestResult<GetRequestTypeByIdDto>>;

    public class GetRequestTypeByIdQueryHandler : RequestHandlerBase<GetRequestTypeByIdQuery, RequestResult<GetRequestTypeByIdDto>, RequestType, Guid>
    {
        public GetRequestTypeByIdQueryHandler(RequestHandlerBaseParameters<RequestType, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<GetRequestTypeByIdDto>> Handle(GetRequestTypeByIdQuery request, CancellationToken ct)
        {
            var requestType = await _generalRepo.GetByIdAsync(request.Id);

            if (requestType == null)
                return RequestResult<GetRequestTypeByIdDto>.Failure("RequestType not found.", ErrorCode.NotFound);

            var requestTypeDto = _mapper.Map<GetRequestTypeByIdDto>(requestType);

            return RequestResult<GetRequestTypeByIdDto>.Success(requestTypeDto, "RequestType retrieved successfully!");
        }
    }
}



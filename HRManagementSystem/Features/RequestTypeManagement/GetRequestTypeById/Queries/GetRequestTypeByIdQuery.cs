namespace HRManagementSystem.Features.RequestTypeManagement.GetRequestTypeById.Queries
{
    public record GetRequestTypeByIdQuery(int Id) : IRequest<RequestResult<GetRequestTypeByIdDto>>;

    public class GetRequestTypeByIdQueryHandler : RequestHandlerBase<GetRequestTypeByIdQuery, RequestResult<GetRequestTypeByIdDto>, RequestType, int>
    {
        public GetRequestTypeByIdQueryHandler(RequestHandlerBaseParameters<RequestType, int> parameters)
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


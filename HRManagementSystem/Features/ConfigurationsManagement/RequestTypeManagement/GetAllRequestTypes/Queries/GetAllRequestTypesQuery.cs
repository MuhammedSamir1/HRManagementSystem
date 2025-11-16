using AutoMapper.QueryableExtensions;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.GetAllRequestTypes.Queries
{
    public record GetAllRequestTypesQuery() : IRequest<RequestResult<IEnumerable<GetAllRequestTypesDto>>>;

    public class GetAllRequestTypesQueryHandler : RequestHandlerBase<GetAllRequestTypesQuery, RequestResult<IEnumerable<GetAllRequestTypesDto>>, RequestType, Guid>
    {
        public GetAllRequestTypesQueryHandler(RequestHandlerBaseParameters<RequestType, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<IEnumerable<GetAllRequestTypesDto>>> Handle(GetAllRequestTypesQuery request, CancellationToken ct)
        {
            var requestTypes = await _generalRepo.Get(x => !x.IsDeleted, ct)
               .ProjectTo<GetAllRequestTypesDto>(_mapper.ConfigurationProvider)
               .ToListAsync(ct);

            if (requestTypes is null)
                return RequestResult<IEnumerable<GetAllRequestTypesDto>>.Failure("No request types found.", ErrorCode.NotFound);

            return RequestResult<IEnumerable<GetAllRequestTypesDto>>.Success(requestTypes, "RequestTypes retrieved successfully!");
        }
    }
}



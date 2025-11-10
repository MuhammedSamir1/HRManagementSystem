using AutoMapper.QueryableExtensions;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.CustodyCommon.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetCustodyById.Queries
{
    public sealed class GetCustodyByIdQueryHandler :
          RequestHandlerBase<GetCustodyByIdQuery, RequestResult<ViewCustodyDto>, Custody, int>
    {
        public GetCustodyByIdQueryHandler(
            RequestHandlerBaseParameters<Custody, int> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<ViewCustodyDto>> Handle(
            GetCustodyByIdQuery request,
            CancellationToken ct)
        {

            var baseQuery = _generalRepo.Get(c => c.Id == request.Id && !c.IsDeleted, ct);

            var dto = await baseQuery
                .ProjectTo<ViewCustodyDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);


            if (dto is null)
            {

                return RequestResult<ViewCustodyDto>.Failure(
                    "?????? ???????? ??? ?????? ?? ?? ?????.",
                    ErrorCode.NotFound);
            }


            return RequestResult<ViewCustodyDto>.Success(dto);
        }
    }
}

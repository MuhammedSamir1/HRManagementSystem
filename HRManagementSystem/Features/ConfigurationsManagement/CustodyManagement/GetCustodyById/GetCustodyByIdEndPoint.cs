using HRManagementSystem.Features.Common.CustodyCommon.Dtos;
using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetCustodyById.Queries;

namespace HRManagementSystem.Features.Configurations.CustodyManagement.GetCustodyById
{
    [ApiGroup("Configurations Management", "Custody Management")]
    public class GetCustodyByIdEndPoint : BaseEndPoint<Guid, ResponseViewModel<ViewCustodyDto>>
    {

        public GetCustodyByIdEndPoint(EndPointBaseParameters<Guid> parameters)
            : base(parameters)
        {
        }


        [HttpGet("{id:int}")]
        public async Task<ResponseViewModel<ViewCustodyDto>> GetCustodyById(Guid id, CancellationToken ct)
        {

            var query = new GetCustodyByIdQuery(id);


            var result = await _mediator.Send(query, ct);


            if (!result.isSuccess)
            {

                return ResponseViewModel<ViewCustodyDto>.Failure(result.message, result.errorCode);
            }


            return ResponseViewModel<ViewCustodyDto>.Success(result.data!);
        }
    }
}





using HRManagementSystem.Features.Common.CustodyCommon.Dtos;
using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetCustodyById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetCustodyById
{
    public class GetCustodyByIdEndPoint : BaseEndPoint<int, ResponseViewModel<ViewCustodyDto>>
    {

        public GetCustodyByIdEndPoint(EndPointBaseParameters<int> parameters)
            : base(parameters)
        {
        }


        [HttpGet("{id:int}")]
        public async Task<ResponseViewModel<ViewCustodyDto>> GetCustodyById(int id, CancellationToken ct)
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

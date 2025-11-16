using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.Common.CustodyCommon.Dtos;
using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetAllCustodies.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetAllCustodies
{
    [ApiGroup("Configurations Management", "Custody Management")]
    public class GetAllCustodiesEndPoint : BaseEndPoint<GetAllCustodiesViewModel, ResponseViewModel<PagedList<ViewCustodyDto>>>
    {
        public GetAllCustodiesEndPoint(EndPointBaseParameters<GetAllCustodiesViewModel> parameters) : base(parameters) { }

        [HttpGet("all")]
        public async Task<ResponseViewModel<PagedList<ViewCustodyDto>>> GetAllCustodies([FromQuery] GetAllCustodiesViewModel model, CancellationToken ct)
        {

            var query = _mapper.Map<GetAllCustodiesQuery>(model);


            var result = await _mediator.Send(query, ct);


            if (!result.isSuccess)
                return ResponseViewModel<PagedList<ViewCustodyDto>>.Failure(result.message, result.errorCode);


            return ResponseViewModel<PagedList<ViewCustodyDto>>.Success(result.data!);
        }
    }
}




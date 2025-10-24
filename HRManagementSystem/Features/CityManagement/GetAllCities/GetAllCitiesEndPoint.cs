using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.GetAllCities.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.CityManagement.GetAllCities
{
    public class GetAllCitiesEndPoint
        : BaseEndPoint<GetAllCitiesViewModel, ResponseViewModel<List<ViewAllCitiesViewModel>>>
    {
        public GetAllCitiesEndPoint(EndPointBaseParameters<GetAllCitiesViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpGet("get-all")]
        public async Task<ResponseViewModel<List<ViewAllCitiesViewModel>>> GetAllCities(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAllCitiesQuery(), ct);

            if (!result.isSuccess)
                return ResponseViewModel<List<ViewAllCitiesViewModel>>.Failure(result.errorCode);

            var viewModels = _mapper.Map<List<ViewAllCitiesViewModel>>(result.data);

            return ResponseViewModel<List<ViewAllCitiesViewModel>>.Success(viewModels, "Cities retrieved successfully!");
        }
    }
}

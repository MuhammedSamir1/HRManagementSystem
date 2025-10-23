using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.CityManagement.GetAllCities.ViewModels;
using HRManagementSystem.Features.Common.AddressManagement.GetAllCities.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.CityManagement.GetAllCities
{
    public class GetAllCitiesEndPoint
        : BaseEndPoint<EmptyRequest, ResponseViewModel<List<GetAllCitiesViewModel>>>
    {
        public GetAllCitiesEndPoint(EndPointBaseParameters<EmptyRequest> parameters)
            : base(parameters)
        {
        }

        [HttpGet("get-all")]
        public async Task<ResponseViewModel<List<GetAllCitiesViewModel>>> GetAllCities(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAllCitiesCommand(), ct);

            if (!result.isSuccess)
                return ResponseViewModel<List<GetAllCitiesViewModel>>.Failure(result.errorCode);

            var viewModels = _mapper.Map<List<GetAllCitiesViewModel>>(result.data);

            return ResponseViewModel<List<GetAllCitiesViewModel>>.Success(viewModels, "Cities retrieved successfully!");
        }
    }

    // Request فاضي علشان الـ BaseEndPoint generic محتاج نوع
    public record EmptyRequest();
}

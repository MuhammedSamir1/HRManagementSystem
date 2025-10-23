using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.GetCityById.Commands;
using HRManagementSystem.Features.Common.AddressManagement.GetCityById.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.Common.AddressManagement.AddCity
{
    public class GetCityByIdEndPoint
        : BaseEndPoint<GetCityByIdViewModel, ResponseViewModel<GetCityByIdViewModel>>
    {
        public GetCityByIdEndPoint(EndPointBaseParameters<GetCityByIdViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpGet("get-by-id")]
        public async Task<ResponseViewModel<GetCityByIdViewModel>> GetCityById(
            [FromQuery] GetCityByIdViewModel model, CancellationToken ct)
        {
            // تحقق من صحة البيانات
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<GetCityByIdViewModel>.Failure(validationResult.errorCode);

            // استدعاء الـCommand
            var result = await _mediator.Send(new GetCityByIdCommand(model.Id), ct);

            if (!result.isSuccess)
                return ResponseViewModel<GetCityByIdViewModel>.Failure(result.errorCode);

            // عمل Mapping من Entity لViewModel
            var cityVm = _mapper.Map<GetCityByIdViewModel>(result.data);

            return ResponseViewModel<GetCityByIdViewModel>.Success(cityVm, "City retrieved successfully.");
        }
    }
}

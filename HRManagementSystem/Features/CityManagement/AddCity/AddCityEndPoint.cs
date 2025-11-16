using HRManagementSystem.Features.CityManagement.AddCity.Commands;

namespace HRManagementSystem.Features.CityManagement.AddCity
{
    [ApiGroup("City Management")]
    public class AddCityEndPoint : BaseEndPoint<AddCityViewModel, ResponseViewModel<bool>>
    {
        public AddCityEndPoint(EndPointBaseParameters<AddCityViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("add")]
        public async Task<ResponseViewModel<bool>> AddCity([FromQuery] AddCityViewModel model, CancellationToken ct)
        {
            // التحقق من صحة الـ ViewModel
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            // تحويل ViewModel إلى Command
            var command = _mapper.Map<AddCityCommand>(model);

            // إرسال Command للـ Handler عبر Mediator
            var result = await _mediator.Send(command, ct);

            // إرجاع النتيجة
            if (!result.isSuccess)
                return ResponseViewModel<bool>.Failure(result.errorCode);

            return ResponseViewModel<bool>.Success(true, "City Added Successfully!");
        }
    }
}


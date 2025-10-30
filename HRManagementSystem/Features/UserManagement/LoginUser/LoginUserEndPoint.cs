using HRManagementSystem.Features.AuthManagement.Login.Query;

namespace HRManagementSystem.Features.AuthManagement.Login
{
    public class LoginUserEndPoint : BaseEndPoint<LoginUserRequestViewModel, ResponseViewModel<string>>
    {
        public LoginUserEndPoint(EndPointBaseParameters<LoginUserRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("Login")]
        public async Task<ResponseViewModel<string>> Login([FromQuery] LoginUserRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<string>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new LoginUserQuery(
                                                    model.Username,
                                                    model.Password), ct);

            if (!result.isSuccess) return ResponseViewModel<string>.Failure(result.errorCode);
            return ResponseViewModel<string>.Success(result.data, "User registered Successfully!");
        }
    }
}

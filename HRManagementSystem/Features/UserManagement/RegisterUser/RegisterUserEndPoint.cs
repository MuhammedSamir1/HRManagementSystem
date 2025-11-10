using HRManagementSystem.Features.UserManagement.RegisterUser.Commands;

namespace HRManagementSystem.Features.UserManagement.RegisterUser
{
    public class RegisterUserEndPoint : BaseEndPoint<RegisterUserRequestViewModel, ResponseViewModel<bool>>
    {
        public RegisterUserEndPoint(EndPointBaseParameters<RegisterUserRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("Register")]
        public async Task<ResponseViewModel<bool>> Register([FromQuery] RegisterUserRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new RegisterUserCommand(
                                                    model.Name,
                                                    model.Email,
                                                    model.UserName,
                                                    model.Password,
                                                    model.RoleId
                                                    ), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "User registered Successfully!");
        }
    }
}

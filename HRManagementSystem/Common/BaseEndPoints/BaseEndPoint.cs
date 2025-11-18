using FluentValidation;

namespace HRManagementSystem.Common.BaseEndPoints
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseEndPoint<TRequest, TResponse> : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IValidator<TRequest> _validator;
        protected readonly IMapper _mapper;

        public BaseEndPoint(EndPointBaseParameters<TRequest> parameters)
        {
            _mediator = parameters.Mediator;
            _validator = parameters.Validator;
            _mapper = parameters.Mapper;
        }

        protected ResponseViewModel<TResponse> ValidateRequest(TRequest request)
            => TryValidateRequest(request, out var failureResponse)
                ? ResponseViewModel<TResponse>.Success(default!, "Validation Successful!")
                : failureResponse;

        protected bool TryValidateRequest(TRequest request, out ResponseViewModel<TResponse> failureResponse)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                failureResponse = ResponseViewModel<TResponse>.Failure(errorMessage, ErrorCode.ValidationError);
                return false;
            }

            failureResponse = default!;
            return true;
        }

        protected async Task<ResponseViewModel<TResponse>> HandleRequestAsync(
            TRequest request,
            Func<CancellationToken, Task<RequestResult<TResponse>>> handler,
            CancellationToken ct = default)
        {
            if (!TryValidateRequest(request, out var validationFailure))
                return validationFailure;

            var result = await handler(ct);
            return BuildResponse(result);
        }

        protected async Task<ResponseViewModel<TResponse>> HandleRequestAsync(
            Func<CancellationToken, Task<RequestResult<TResponse>>> handler,
            CancellationToken ct = default)
        {
            var result = await handler(ct);
            return BuildResponse(result);
        }

        protected static ResponseViewModel<TResult> BuildResponse<TResult>(RequestResult<TResult> result)
        {
            if (!result.isSuccess)
            {
                return ResponseViewModel<TResult>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<TResult>.Success(result.data, result.message);
        }
    }
}

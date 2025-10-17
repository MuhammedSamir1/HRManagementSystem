using AutoMapper;
using FluentValidation;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return ResponseViewModel<TResponse>.Failure(errorMessage, ErrorCode.ValidationError);
            }
            return ResponseViewModel<TResponse>.Success(default!, "Validation Successful!");
        }
    }
}

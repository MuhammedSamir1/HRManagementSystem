using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.IsStateExistWithSameCode.Query;

namespace HRManagementSystem.Features.StateManagement.AddState.Command
{
    public sealed record AddStateCommand(string Code, string Name, int CountryId) : IRequest<RequestResult<ViewStateDto>>;


    public sealed class AddStateCommandHandler : RequestHandlerBase<AddStateCommand,
        RequestResult<ViewStateDto>, State, int>
    {
        public AddStateCommandHandler(RequestHandlerBaseParameters<State, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewStateDto>> Handle(AddStateCommand request, CancellationToken ct)
        {
            // Check if country exists
            //var countryExists = await _mediator.Send(IsCountryExistQuery(request.CountryId));
            //if (countryExists!=null)
            //    return RequestResult<ViewStateDto>.Failure(ErrorCode.CountryNotFound);



            // Check if state with same code already exists
            var stateExistsResult = await _mediator.Send(new IsStateExistWithSameCodeQuery(request.Code, request.CountryId), ct);

            if (!stateExistsResult.isSuccess)
                return RequestResult<ViewStateDto>.Failure(ErrorCode.StateAlreadyExists);

            // Create new state
            var state = _mapper.Map<State>(request);

            await _generalRepo.AddAsync(state, ct);


            var stateDto = _mapper.Map<ViewStateDto>(state);
            return RequestResult<ViewStateDto>.Success(stateDto);
        }
    }
}

using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Data.Repositories;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.IsStateExistWithSameCode.Query;
using HRManagementSystem.Features.StateManagement.GetStateById.Queries;
namespace HRManagementSystem.Features.StateManagement.UpdateState.Command
{
    public sealed record UpdateStateCommand(int Id, string Code, string Name, int CountryId) : IRequest<RequestResult<ViewStateDto>>;
    public sealed class UpdateStateCommandHandler : RequestHandlerBase<UpdateStateCommand,
        RequestResult<ViewStateDto>, State, int>
    {
        private readonly IGeneralRepository<Country, int> _countryRepo;

        public UpdateStateCommandHandler(
            RequestHandlerBaseParameters<State, int> parameters,
            IGeneralRepository<Country, int> countryRepo)
            : base(parameters)
        {
            _countryRepo = countryRepo;
        }

        public override async Task<RequestResult<ViewStateDto>> Handle(UpdateStateCommand request, CancellationToken ct)
        {
            // Check if state exists
            //Refactor to use IsExistQuery
            var state = await _mediator.Send(new GetStateByIdQuery(request.Id));

            if (state is null)
                return RequestResult<ViewStateDto>.Failure(ErrorCode.StateNotFound);

            // Check if country exists
            //Refactor to use IsCountryExistQuery


            // Check if state with same code already exists (excluding current state)
            var stateWithSameCode = await _mediator.Send(new IsStateExistWithSameCodeQuery(request.Code, request.CountryId));

            if (stateWithSameCode != null)
                return RequestResult<ViewStateDto>.Failure(ErrorCode.StateAlreadyExists);

            // Update state
            var updatedState = _mapper.Map<State>(state);
            var res = await _generalRepo.UpdateAsync(updatedState, ct);


            var stateDto = _mapper.Map<ViewStateDto>(updatedState);
            return RequestResult<ViewStateDto>.Success(stateDto, "State updated successfully.");
        }
    }

}

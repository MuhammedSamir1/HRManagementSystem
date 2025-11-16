using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.IsAnyChildAssignedGeneric;

namespace HRManagementSystem.Features.StateManagement.DeleteState.Command
{
    public sealed record DeleteStateCommand(Guid Id) : IRequest<RequestResult<bool>>;

    public sealed class DeleteStateCommandHandler : RequestHandlerBase<DeleteStateCommand,
        RequestResult<bool>, State, Guid>
    {
        public DeleteStateCommandHandler(RequestHandlerBaseParameters<State, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteStateCommand request, CancellationToken ct)
        {
            // Check if any city assigned to this state 

            var hasCities = await _mediator.Send(new IsAnyChildAssignedQuery<State, City, Guid>(request.Id), ct);
            if (hasCities.data)
            {
                return RequestResult<bool>.Failure("Cannot delete state. There are cities assigned to this state.");
            }
            await _generalRepo.SoftDeleteAsync(request.Id, ct);
            return RequestResult<bool>.Success(true, "State deleted successfully.");
        }
    }
}


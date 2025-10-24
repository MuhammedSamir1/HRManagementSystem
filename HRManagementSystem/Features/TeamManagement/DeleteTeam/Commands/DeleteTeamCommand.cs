using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;

namespace HRManagementSystem.Features.TeamManagement.DeleteTeam.Commands
{
    public sealed record DeleteTeamCommand(int Id) : IRequest<RequestResult<bool>>;


    public sealed class DeleteTeamCommandHandler : RequestHandlerBase<DeleteTeamCommand,
        RequestResult<bool>, Team, int>
    {
        public DeleteTeamCommandHandler(RequestHandlerBaseParameters<Team, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, cancellationToken);
            if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.TeamNotFound);
            return RequestResult<bool>.Success(isDeleted);
        }
    }
}

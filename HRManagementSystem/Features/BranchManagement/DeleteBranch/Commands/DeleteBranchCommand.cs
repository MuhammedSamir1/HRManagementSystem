using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Commands
{
    public sealed record DeleteBranchCommand(int Id) : IRequest<RequestResult<bool>>;


    public sealed class DeleteBranchCommandHandler : RequestHandlerBase<DeleteBranchCommand,
        RequestResult<bool>, Branch, int>
    {
        public DeleteBranchCommandHandler(RequestHandlerBaseParameters<Branch, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, cancellationToken);
            if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.BranchNotFound);
            return RequestResult<bool>.Success(isDeleted);
        }
    }
}

using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.DeleteBonus.Commands
{
    public sealed record DeleteBonusCommand(Guid Id) : IRequest<RequestResult<bool>>;

    public class DeleteBonusCommandHandler : RequestHandlerBase<DeleteBonusCommand, RequestResult<bool>, Bonus, Guid>
    {
        public DeleteBonusCommandHandler(RequestHandlerBaseParameters<Bonus, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteBonusCommand request, CancellationToken ct)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted)
                return RequestResult<bool>.Failure("Bonus not found or wasn't deleted successfully!", ErrorCode.NotFound);

            return RequestResult<bool>.Success(true, "Bonus deleted successfully!");
        }
    }
}


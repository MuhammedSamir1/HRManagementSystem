using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.DeleteBonus.Commands
{
    public sealed record DeleteBonusCommand(int Id) : IRequest<RequestResult<string>>;

    public class DeleteBonusCommandHandler : RequestHandlerBase<DeleteBonusCommand, RequestResult<string>, Bonus, int>
    {
        public DeleteBonusCommandHandler(RequestHandlerBaseParameters<Bonus, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<string>> Handle(DeleteBonusCommand request, CancellationToken ct)
        {
            var bonus = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (bonus == null)
                return RequestResult<string>.Failure("Bonus not found.", ErrorCode.NotFound);

            var isDeleted = await _generalRepo.DeleteAsync(bonus, ct);

            if (!isDeleted)
                return RequestResult<string>.Failure("Bonus wasn't deleted successfully!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success("Bonus deleted successfully!");
        }
    }
}

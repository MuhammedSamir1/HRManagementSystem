using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.UpdateBonus.Commands
{
    public sealed record UpdateBonusCommand(
        int Id,
        string Title,
        string? Description,
        decimal Amount,
        BonusType BonusType,
        DateTime BonusDate,
        DateTime? PaymentDate,
        bool IsPaid,
        int? EmployeeId)
        : IRequest<RequestResult<bool>>;

    public class UpdateBonusCommandHandler : RequestHandlerBase<UpdateBonusCommand, RequestResult<bool>, Bonus, int>
    {
        public UpdateBonusCommandHandler(RequestHandlerBaseParameters<Bonus, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(UpdateBonusCommand request, CancellationToken ct)
        {
            var bonus = await _generalRepo.GetByIdWithTracking(request.Id);

            if (bonus == null || bonus.IsDeleted)
                return RequestResult<bool>.Failure("Bonus not found.", ErrorCode.NotFound);

            bonus.Title = request.Title;
            bonus.Description = request.Description;
            bonus.Amount = request.Amount;
            bonus.BonusType = request.BonusType;
            bonus.BonusDate = request.BonusDate;
            bonus.PaymentDate = request.PaymentDate;
            bonus.IsPaid = request.IsPaid;
            bonus.EmployeeId = request.EmployeeId;

            await _generalRepo.UpdateAsync(bonus, ct);

            return RequestResult<bool>.Success(true, "Bonus updated successfully!");
        }
    }
}

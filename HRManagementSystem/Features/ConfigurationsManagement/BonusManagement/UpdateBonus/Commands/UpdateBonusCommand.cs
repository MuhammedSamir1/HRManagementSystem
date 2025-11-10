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
        : IRequest<RequestResult<string>>;

    public class UpdateBonusCommandHandler : RequestHandlerBase<UpdateBonusCommand, RequestResult<string>, Bonus, int>
    {
        public UpdateBonusCommandHandler(RequestHandlerBaseParameters<Bonus, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<string>> Handle(UpdateBonusCommand request, CancellationToken ct)
        {
            var bonus = await _generalRepo.GetByIdAsync(request.Id, ct);

            if (bonus == null)
                return RequestResult<string>.Failure("Bonus not found.", ErrorCode.NotFound);

            _mapper.Map(request, bonus);

            var isUpdated = await _generalRepo.UpdateAsync(bonus, ct);

            if (!isUpdated)
                return RequestResult<string>.Failure("Bonus wasn't updated successfully!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success("Bonus updated successfully!");
        }
    }
}

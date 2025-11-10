using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.AddBonus.Commands
{
    public sealed record AddBonusCommand(
        string Title,
        string? Description,
        decimal Amount,
        BonusType BonusType,
        DateTime BonusDate,
        DateTime? PaymentDate,
        bool IsPaid,
        int? EmployeeId)
        : IRequest<RequestResult<int>>;

    public class AddBonusCommandHandler : RequestHandlerBase<AddBonusCommand, RequestResult<int>, Bonus, int>
    {
        public AddBonusCommandHandler(RequestHandlerBaseParameters<Bonus, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<int>> Handle(AddBonusCommand request, CancellationToken ct)
        {
            var bonus = _mapper.Map<Bonus>(request);

            var isAdded = await _generalRepo.AddAsync(bonus, ct);

            if (!isAdded)
                return RequestResult<int>.Failure("Bonus wasn't added successfully!", ErrorCode.InternalServerError);

            return RequestResult<int>.Success(bonus.Id, "Bonus added successfully!");
        }
    }
}

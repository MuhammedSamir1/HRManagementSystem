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
        bool IsPaid)
        : IRequest<RequestResult<Guid>>;

    public class AddBonusCommandHandler : RequestHandlerBase<AddBonusCommand, RequestResult<Guid>, Bonus, Guid>
    {
        public AddBonusCommandHandler(RequestHandlerBaseParameters<Bonus, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<Guid>> Handle(AddBonusCommand request, CancellationToken ct)
        {
            var bonus = _mapper.Map<Bonus>(request);

            var isAdded = await _generalRepo.AddAsync(bonus, ct);

            if (!isAdded)
                return RequestResult<Guid>.Failure("Bonus wasn't added successfully!", ErrorCode.InternalServerError);

            return RequestResult<Guid>.Success(bonus.Id, "Bonus added successfully!");
        }
    }
}


using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;

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
        : IRequest<RequestResult<CreatedIdDto>>;

    public class AddBonusCommandHandler : RequestHandlerBase<AddBonusCommand, RequestResult<CreatedIdDto>, Bonus, int>
    {
        public AddBonusCommandHandler(RequestHandlerBaseParameters<Bonus, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddBonusCommand request, CancellationToken ct)
        {
            var bonus = _mapper.Map<AddBonusCommand, Bonus>(request);

            var isAdded = await _generalRepo.AddAsync(bonus, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Bonus wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(bonus);
            return RequestResult<CreatedIdDto>.Success(mapped, "Bonus added successfully!");
        }
    }
}


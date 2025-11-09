using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.HolidayManagement.IsHolidayOverlapping;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.HolidayManagement.AddHoliday.Commands
{
    public sealed class AddHolidayCommandHandler : RequestHandlerBase<AddHolidayCommand, RequestResult<bool>, Holiday, int>
    {
        public AddHolidayCommandHandler(RequestHandlerBaseParameters<Holiday, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(AddHolidayCommand request, CancellationToken ct)
        {
            // 1. التحقق من التداخل (No Overlap)
            var overlapValidation = await _mediator.Send(
                new IsHolidayOverlappingQuery(request.StartDate, request.EndDate, request.CompanyId), ct);

            if (!overlapValidation.isSuccess)
            {
                return RequestResult<bool>.Failure(overlapValidation.message, overlapValidation.errorCode);
            }

            // 2. التحقق من  (Unique Name Check)
            var isNameDuplicate = await _generalRepo
                .Get(h => h.Name == request.Name && h.CompanyId == request.CompanyId, ct)
                .AnyAsync(ct);

            if (isNameDuplicate)
            {
                return RequestResult<bool>.Failure($"Holiday named '{request.Name}' already exists for this company.", ErrorCode.Conflict);
            }

            // 3. adding the holiday
            var holiday = _mapper.Map<Holiday>(request);

            var isAdded = await _generalRepo.AddAsync(holiday, ct);

            if (!isAdded)
                return RequestResult<bool>.Failure("Holiday wasn't added successfully to the database!", ErrorCode.InternalServerError);

            return RequestResult<bool>.Success(true, "Holiday added successfully!");
        }
    }
}

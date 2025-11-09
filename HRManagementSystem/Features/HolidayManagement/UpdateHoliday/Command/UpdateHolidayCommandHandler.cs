using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.HolidayManagement.IsHolidayOverlapping;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.HolidayManagement.UpdateHoliday.Command
{
    public sealed class UpdateHolidayCommandHandler : RequestHandlerBase<UpdateHolidayCommand, RequestResult<bool>, Holiday, int>
    {
        public UpdateHolidayCommandHandler(RequestHandlerBaseParameters<Holiday, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(UpdateHolidayCommand request, CancellationToken ct)
        {
            // 1.  (Existence Check)
            var existingHoliday = await _generalRepo.GetByIdWithTracking(request.Id);
            if (existingHoliday == null)
            {
                return RequestResult<bool>.Failure("Holiday not found.", ErrorCode.NotFound);
            }

            // 2.  من التداخل (No Overlap) - استثناء الاجازة نفسها
            var overlapValidation = await _mediator.Send(
                new IsHolidayOverlappingQuery(
                    request.StartDate,
                    request.EndDate,
                    request.CompanyId,
                    request.Id 
                ), ct);

            if (!overlapValidation.isSuccess)
            {
                return RequestResult<bool>.Failure(overlapValidation.message, overlapValidation.errorCode);
            }

          
            var isNameDuplicate = await _generalRepo
                .Get(h => h.Id != request.Id && 
                          h.Name == request.Name &&
                          h.CompanyId == request.CompanyId, ct)
                .AnyAsync(ct);

            if (isNameDuplicate)
            {
                return RequestResult<bool>.Failure($"Holiday named '{request.Name}' already exists for this company.", ErrorCode.Conflict);
            }

    
            _mapper.Map(request, existingHoliday);

            var isUpdated = await _generalRepo.UpdateAsync(existingHoliday, ct);

            if (!isUpdated)
                return RequestResult<bool>.Failure("Holiday wasn't updated successfully!", ErrorCode.InternalServerError);

            return RequestResult<bool>.Success(true, "Holiday updated successfully!");
        }
    }
}

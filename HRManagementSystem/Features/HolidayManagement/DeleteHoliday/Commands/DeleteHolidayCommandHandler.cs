namespace HRManagementSystem.Features.HolidayManagement.DeleteHoliday.Commands
{
    public sealed class DeleteHolidayCommandHandler : RequestHandlerBase<DeleteHolidayCommand, RequestResult<bool>, Holiday, int>
    {
        public DeleteHolidayCommandHandler(RequestHandlerBaseParameters<Holiday, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteHolidayCommand request, CancellationToken ct)
        {
            // 1.    (Existence Check)
            var existingHoliday = await _generalRepo.GetByIdAsync(request.Id);
            if (existingHoliday == null)
            {
                return RequestResult<bool>.Failure("Holiday not found or already deleted.", ErrorCode.NotFound);
            }

            // 2.(Soft Delete)
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted)
            {
                return RequestResult<bool>.Failure("Failed to delete the holiday.", ErrorCode.InternalServerError);
            }

            return RequestResult<bool>.Success(true, "Holiday deleted successfully!");
        }
    }
}

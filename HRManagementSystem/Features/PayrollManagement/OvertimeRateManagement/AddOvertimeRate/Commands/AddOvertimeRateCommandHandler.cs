using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.PayrollManagement.OvertimeRateManagement.AddOvertimeRate.Commands
{
    public sealed class AddOvertimeRateCommandHandler :
         RequestHandlerBase<AddOvertimeRateCommand, RequestResult<OvertimeRateDto>, OvertimeRate, int>
    {
     

        public AddOvertimeRateCommandHandler(
            RequestHandlerBaseParameters<OvertimeRate, int> parameters)
            : base(parameters)
        {
           
        }

        public override async Task<RequestResult<OvertimeRateDto>> Handle(AddOvertimeRateCommand request, CancellationToken ct)
        {
         
            var isNameConflict = await _generalRepo.CheckAnyAsync(
                p => p.Name.ToLower() == request.Name.ToLower() && !p.IsDeleted,
                ct);

            if (isNameConflict)
            {
                return RequestResult<OvertimeRateDto>.Failure(
                    "اسم سعر العمل الإضافي موجود بالفعل. يجب أن يكون فريداً.",
                    ErrorCode.Conflict);
            }

       
            var newRate = _mapper.Map<OvertimeRate>(request);

 
            newRate.IsDeleted = false;

            await _generalRepo.AddAsync(newRate, ct);

            //var isSaved = await _generalRepo.CommitAsync(ct);

            //if (!isSaved)
            //{
            //    return RequestResult<OvertimeRateDto>.Failure("فشل في إضافة سعر العمل الإضافي.", ErrorCode.InternalServerError);
            //}

            // 5. Mapping الكيان المحفوظ إلى DTO وإرجاعه
            var dto = _mapper.Map<OvertimeRateDto>(newRate);

            return RequestResult<OvertimeRateDto>.Success(dto, "تم إضافة سعر العمل الإضافي بنجاح.");
        }
    }
}

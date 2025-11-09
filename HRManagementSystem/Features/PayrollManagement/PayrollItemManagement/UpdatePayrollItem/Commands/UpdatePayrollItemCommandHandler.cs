using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.UpdatePayrollItem.Commands
{
    public sealed class UpdatePayrollItemCommandHandler :
     RequestHandlerBase<UpdatePayrollItemCommand, RequestResult<PayrollItemDto>, PayrollItem, int>
    {
        private readonly IMapper _mapper;

        public UpdatePayrollItemCommandHandler(
            RequestHandlerBaseParameters<PayrollItem, int> parameters,
            IMapper mapper)
            : base(parameters)
        {
            _mapper = mapper;
        }

        public override async Task<RequestResult<PayrollItemDto>> Handle(UpdatePayrollItemCommand request, CancellationToken ct)
        {
            // 1. التحقق من وجود الكيان (Lookup)
            var existingItem = await _generalRepo.GetByIdAsync(request.Id);

            if (existingItem == null || existingItem.IsDeleted)
            {
                return RequestResult<PayrollItemDto>.Failure("عنصر المرتب غير موجود أو تم حذفه.", ErrorCode.NotFound);
            }

          
            var isNameConflict = await _generalRepo.CheckAnyAsync(
             
                p => p.Id != request.Id &&
                     p.Name.ToLower() == request.Name.ToLower() &&
                     !p.IsDeleted,
                ct);

            if (isNameConflict)
            {
                return RequestResult<PayrollItemDto>.Failure(
                    "هذا الاسم موجود بالفعل لعنصر مرتب آخر. يجب أن يكون فريداً.",
                    ErrorCode.Conflict);
            }


            _mapper.Map(request, existingItem);
         

         
            _generalRepo.UpdateAsync(existingItem,ct);

            //var isSaved = await _generalRepo.CommitAsync(ct);

            //if (!isSaved)
            //{
            //    return RequestResult<PayrollItemDto>.Failure("فشل في تحديث عنصر المرتب.", ErrorCode.InternalServerError);
            //}

            // 5. Mapping الكيان المحدث إلى DTO وإرجاعه
            var dto = _mapper.Map<PayrollItemDto>(existingItem);

            return RequestResult<PayrollItemDto>.Success(dto, "تم تحديث عنصر المرتب بنجاح.");
        }
    }
}

using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.PayrollManagement.OvertimeRateManagement.GetOvertimeRateById.Queries
{
    public sealed class GetOvertimeRateByIdQueryHandler :
        RequestHandlerBase<GetOvertimeRateByIdQuery, RequestResult<OvertimeRateDto>, OvertimeRate, int>
    {
        private readonly IMapper _mapper;

        public GetOvertimeRateByIdQueryHandler(
            RequestHandlerBaseParameters<OvertimeRate, int> parameters,
            IMapper mapper)
            : base(parameters)
        {
            _mapper = mapper;
        }

        public override async Task<RequestResult<OvertimeRateDto>> Handle(GetOvertimeRateByIdQuery request, CancellationToken ct)
        {
            // 1. جلب العنصر من الريبو العام
            var item = await _generalRepo.GetByIdAsync(request.Id);

            // 2. التحقق من وجود العنصر
            if (item == null)
            {
                return RequestResult<OvertimeRateDto>.Failure(
                    "عنصر معدل العمل الإضافي غير موجود أو تم حذفه.",
                    ErrorCode.NotFound);
            }

            // 3. تحويل الكيان إلى DTO
            var dto = _mapper.Map<OvertimeRateDto>(item);

            // 4. إرجاع النتيجة بنجاح
            return RequestResult<OvertimeRateDto>.Success(dto, "تم جلب بيانات معدل العمل الإضافي بنجاح.");
        }
    }
}

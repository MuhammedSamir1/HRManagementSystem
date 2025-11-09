namespace HRManagementSystem.Features.PayrollManagement.OvertimeRateManagement.DeleteOvertimeRate.Commands
{
    public sealed class DeleteOvertimeRateCommandHandler :
         RequestHandlerBase<DeleteOvertimeRateCommand, RequestResult<bool>, OvertimeRate, int>
    {
        private readonly ILogger<DeleteOvertimeRateCommandHandler> _logger;

        // إذا عندك repository آخر للتحقق من وجود مراجع (مثلاً payroll items) أضفه كـ parameter هنا.
        public DeleteOvertimeRateCommandHandler(
            RequestHandlerBaseParameters<OvertimeRate, int> parameters,
            IMapper mapper,
            ILogger<DeleteOvertimeRateCommandHandler> logger)
            : base(parameters)
        {
            _logger = logger;
        }

        public override async Task<RequestResult<bool>> Handle(DeleteOvertimeRateCommand request, CancellationToken ct)
        {
            try
            {
                // 1. جلب الكيان (بمنع الاستعلام اللاحق إذا ليس موجود)
                var entity = await _generalRepo.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return RequestResult<bool>.Failure(
                        "معدل العمل الإضافي غير موجود أو تم حذفه سابقًا.",
                        ErrorCode.NotFound);
                }

                // 2. تحقق من وجود مراجع في جداول أخرى (اختياري ولكن موصى به)
                // مثال: إذا عندكم جدول PayrollItems يحوي FK إلى OvertimeRateId
                // يجب التحقق لمنع حذف قد يكسر القيود المرجعية أو التضارب التاريخي.
                //
                // if (await _someRepo.CheckAnyAsync(pi => pi.OvertimeRateId == request.Id, ct))
                // {
                //     return RequestResult<bool>.Failure(
                //         "لا يمكن حذف هذا المعدل لأنه مستخدم في سجلات الرواتب أو عناصر الرواتب.",
                //         ErrorCode.Conflict);
                // }

                // 3. نفّذ soft delete عبر الريبوزيتوري العام
                var deleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

                if (!deleted)
                {
                    _logger.LogWarning("SoftDeleteAsync returned false for OvertimeRate.Id={Id}", request.Id);
                    return RequestResult<bool>.Failure(
                        "فشل تعطيل معدل العمل الإضافي. حاول مرة أخرى أو تواصل مع الدعم.",
                        ErrorCode.BadRequest);
                }

                // 4. يمكن هنا عمل عمليات إضافية بعد الحذف: إبطال الكاش، تسجيل تدقيق، نشر حدث...
                // مثال تعليقى لإبطال الكاش:
                // _cache.Remove("OvertimeRates:All");
                //
                // أو نشر إشعار:
                // await _mediator.Publish(new OvertimeRateChangedNotification(request.Id), ct);

                // 5. إرجاع النجاح
                return RequestResult<bool>.Success(true, "تم تعطيل معدل العمل الإضافي بنجاح.");
            }
            catch (OperationCanceledException)
            {
                // تحمّل إلغاء الطلب
                _logger.LogInformation("DeleteOvertimeRateCommand cancelled for Id={Id}", request.Id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting OvertimeRate Id={Id}", request.Id);
                return RequestResult<bool>.Failure(
                    "حدث خطأ غير متوقع أثناء محاولة حذف معدل العمل الإضافي.",
                    ErrorCode.BadRequest);
            }
        }
    }
}

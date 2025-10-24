using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;

namespace HRManagementSystem.Features.CountryManagement.GetCountryById
{
    public sealed class GetCountryByIdQueryHandler : RequestHandlerBase<GetCountryByIdQuery, ResponseViewModel<ViewCountryDto>, Country, int>
    {
        // حقن البارامترات الأساسية
        public GetCountryByIdQueryHandler(RequestHandlerBaseParameters<Country, int> parameters) : base(parameters)
        {
        }

        public override async Task<ResponseViewModel<ViewCountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            // 1. استرجاع الكيان باستخدام GetByIdAsync (يفترض أنه للقراءة/بدون تتبع)
            var countryEntity = await _generalRepo.GetByIdAsync(request.Id);

            if (countryEntity == null)
            {
                // إرجاع خطأ عدم العثور باستخدام كود الخطأ
                return ResponseViewModel<ViewCountryDto>.Failure(ErrorCode.NotFound);
            }

            // 2. تحويل Entity إلى DTO للإرجاع (باستخدام الـ Mapper)
            var countryDto = _mapper.Map<ViewCountryDto>(countryEntity);

            return ResponseViewModel<ViewCountryDto>.Success(countryDto);
        }
    }
}

using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.GetPayrollItemById.Queries
{
    public sealed class GetPayrollItemByIdQueryHandler :
     RequestHandlerBase<GetPayrollItemByIdQuery, RequestResult<PayrollItemDto>, PayrollItem, int>
    {
        public GetPayrollItemByIdQueryHandler(
            RequestHandlerBaseParameters<PayrollItem, int> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<PayrollItemDto>> Handle(GetPayrollItemByIdQuery request, CancellationToken ct)
        {
            // 1
            var item = await _generalRepo.GetByIdAsync(request.Id);

            if (item == null)
            {
                return RequestResult<PayrollItemDto>.Failure("???? ?????? ??? ????? ?? ?? ????.", ErrorCode.NotFound);
            }

            // 2. Mapping ??? DTO
            var dto = _mapper.Map<PayrollItemDto>(item);

            return RequestResult<PayrollItemDto>.Success(dto, "  ??????  ?????? ?????.");
        }
    }
}

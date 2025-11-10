using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetOvertimeRateById.Queries
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
            // 1. ??? ?????? ?? ?????? ?????
            var item = await _generalRepo.GetByIdAsync(request.Id);

            // 2. ?????? ?? ???? ??????
            if (item == null)
            {
                return RequestResult<OvertimeRateDto>.Failure(
                    "???? ???? ????? ??????? ??? ????? ?? ?? ????.",
                    ErrorCode.NotFound);
            }

            // 3. ????? ?????? ??? DTO
            var dto = _mapper.Map<OvertimeRateDto>(item);

            // 4. ????? ??????? ?????
            return RequestResult<OvertimeRateDto>.Success(dto, "?? ??? ?????? ???? ????? ??????? ?????.");
        }
    }
}

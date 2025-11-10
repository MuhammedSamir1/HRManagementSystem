using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.UpdateOvertimeRate.Commands
{
    public sealed class UpdateOvertimeRateCommandHandler :
         RequestHandlerBase<UpdateOvertimeRateCommand, RequestResult<OvertimeRateDto>, OvertimeRate, int>
    {
        private readonly IMapper _mapper;

        public UpdateOvertimeRateCommandHandler(
            RequestHandlerBaseParameters<OvertimeRate, int> parameters,
            IMapper mapper)
            : base(parameters)
        {
            _mapper = mapper;
        }

        public override async Task<RequestResult<OvertimeRateDto>> Handle(UpdateOvertimeRateCommand request, CancellationToken ct)
        {
            // 1. ?????? ?? ???? ?????? (Lookup)
            var existingRate = await _generalRepo.GetByIdAsync(request.Id);

            if (existingRate == null)
            {
                return RequestResult<OvertimeRateDto>.Failure("??? ????? ??????? ??? ?????.", ErrorCode.NotFound);
            }

            var isNameConflict = await _generalRepo.CheckAnyAsync(
                p => p.Id != request.Id &&
                     p.Name.ToLower() == request.Name.ToLower() &&
                     !p.IsDeleted,
                ct);

            if (isNameConflict)
            {
                return RequestResult<OvertimeRateDto>.Failure(
                    "??? ????? ????? ?????? ???? ??? ????? ???. ??? ?? ???? ??????.",
                    ErrorCode.Conflict);
            }

            _mapper.Map(request, existingRate);

            existingRate.IsDeleted = !request.IsActive;


            _generalRepo.UpdateAsync(existingRate, ct);

            //var isSaved = await _generalRepo.CommitAsync(ct);

            //if (!isSaved)
            //{
            //    return RequestResult<OvertimeRateDto>.Failure("??? ?? ????? ??? ????? ???????.", ErrorCode.InternalServerError);
            //}


            var dto = _mapper.Map<OvertimeRateDto>(existingRate);

            return RequestResult<OvertimeRateDto>.Success(dto, "?? ????? ??? ????? ??????? ?????.");
        }
    }
}

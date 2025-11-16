using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.AddOvertimeRate.Commands
{
    public sealed class AddOvertimeRateCommandHandler :
         RequestHandlerBase<AddOvertimeRateCommand, RequestResult<OvertimeRateDto>, OvertimeRate, Guid>
    {


        public AddOvertimeRateCommandHandler(
            RequestHandlerBaseParameters<OvertimeRate, Guid> parameters)
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
                    "??? ??? ????? ??????? ????? ??????. ??? ?? ???? ??????.",
                    ErrorCode.Conflict);
            }


            var newRate = _mapper.Map<OvertimeRate>(request);


            newRate.IsDeleted = false;

            await _generalRepo.AddAsync(newRate, ct);

            //var isSaved = await _generalRepo.CommitAsync(ct);

            //if (!isSaved)
            //{
            //    return RequestResult<OvertimeRateDto>.Failure("??? ?? ????? ??? ????? ???????.", ErrorCode.InternalServerError);
            //}

            // 5. Mapping ?????? ??????? ??? DTO ???????
            var dto = _mapper.Map<OvertimeRateDto>(newRate);

            return RequestResult<OvertimeRateDto>.Success(dto, "?? ????? ??? ????? ??????? ?????.");
        }
    }
}


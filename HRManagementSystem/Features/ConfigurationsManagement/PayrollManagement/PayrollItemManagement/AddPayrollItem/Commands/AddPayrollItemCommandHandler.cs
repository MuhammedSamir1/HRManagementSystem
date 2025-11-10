using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.AddPayrollItem.Commands
{
    public sealed class AddPayrollItemCommandHandler :
    RequestHandlerBase<AddPayrollItemCommand, RequestResult<PayrollItemDto>, PayrollItem, int>
    {


        public AddPayrollItemCommandHandler(
            RequestHandlerBaseParameters<PayrollItem, int> parameters)
            : base(parameters)
        {

        }

        public override async Task<RequestResult<PayrollItemDto>> Handle(AddPayrollItemCommand request, CancellationToken ct)
        {
            var isNameConflict = await _generalRepo.CheckAnyAsync(
                p => p.Name.ToLower() == request.Name.ToLower() && !p.IsDeleted,
                ct);

            if (isNameConflict)
            {

                return RequestResult<PayrollItemDto>.Failure(
                    "??? ????? ????? ??????. ??? ?? ???? ??? ???? ?????? ??????.",
                    ErrorCode.Conflict);
            }

            // 2. Mapping ??? ?????? (Entity)
            var newPayrollItem = _mapper.Map<PayrollItem>(request);
            newPayrollItem.IsDeleted = false;

            await _generalRepo.AddAsync(newPayrollItem, ct);


            //var isSaved = await _generalRepo.CommitAsync(ct);

            //if (!isSaved)
            //{
            //    return RequestResult<PayrollItemDto>.Failure("??? ?? ??? ???? ?????? ??????.", ErrorCode.InternalServerError);
            //}

            // 4. Mapping ?????? ??????? ??? DTO ???????
            var dto = _mapper.Map<PayrollItemDto>(newPayrollItem);

            return RequestResult<PayrollItemDto>.Success(dto, "?? ????? ???? ?????? ?????.");
        }
    }
}

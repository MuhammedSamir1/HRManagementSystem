using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.UpdatePayrollItem.Commands
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
            // 1. ?????? ?? ???? ?????? (Lookup)
            var existingItem = await _generalRepo.GetByIdAsync(request.Id);

            if (existingItem == null || existingItem.IsDeleted)
            {
                return RequestResult<PayrollItemDto>.Failure("???? ?????? ??? ????? ?? ?? ????.", ErrorCode.NotFound);
            }


            var isNameConflict = await _generalRepo.CheckAnyAsync(

                p => p.Id != request.Id &&
                     p.Name.ToLower() == request.Name.ToLower() &&
                     !p.IsDeleted,
                ct);

            if (isNameConflict)
            {
                return RequestResult<PayrollItemDto>.Failure(
                    "??? ????? ????? ?????? ????? ???? ???. ??? ?? ???? ??????.",
                    ErrorCode.Conflict);
            }


            _mapper.Map(request, existingItem);



            _generalRepo.UpdateAsync(existingItem, ct);

            //var isSaved = await _generalRepo.CommitAsync(ct);

            //if (!isSaved)
            //{
            //    return RequestResult<PayrollItemDto>.Failure("??? ?? ????? ???? ??????.", ErrorCode.InternalServerError);
            //}

            // 5. Mapping ?????? ?????? ??? DTO ???????
            var dto = _mapper.Map<PayrollItemDto>(existingItem);

            return RequestResult<PayrollItemDto>.Success(dto, "?? ????? ???? ?????? ?????.");
        }
    }
}

using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.DeleteCustody.Commands
{
    public sealed class DeleteCustodyCommandHandler : RequestHandlerBase<DeleteCustodyCommand, RequestResult<bool>, Custody, Guid>
    {



        public DeleteCustodyCommandHandler(
            RequestHandlerBaseParameters<Custody, Guid> parameters
         )
            : base(parameters)
        {

        }

        public override async Task<RequestResult<bool>> Handle(DeleteCustodyCommand request, CancellationToken ct)
        {

            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted)
            {

                return RequestResult<bool>.Failure("??? ?? ??? ??????. ?? ???? ?????? ??? ??????.", ErrorCode.NotFound);
            }

            // 2. ??? ?????????


            return RequestResult<bool>.Success(true, "?? ??? ?????? ????? .");
        }
    }
}


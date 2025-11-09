namespace HRManagementSystem.Features.CustodyManagement.DeleteCustody.Commands
{
    public sealed class DeleteCustodyCommandHandler : RequestHandlerBase<DeleteCustodyCommand, RequestResult<bool>, Custody, int>
    {
        

      
        public DeleteCustodyCommandHandler(
            RequestHandlerBaseParameters<Custody, int> parameters
         )
            : base(parameters)
        {
         
        }

        public override async Task<RequestResult<bool>> Handle(DeleteCustodyCommand request, CancellationToken ct)
        {
          
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            if (!isDeleted)
            {
              
                return RequestResult<bool>.Failure("فشل في حذف العهدة. قد تكون العهدة غير موجودة.", ErrorCode.NotFound);
            }

            // 2. حفظ التغييرات
          

            return RequestResult<bool>.Success(true, "تم حذف العهدة بنجاح .");
        }
    }
}

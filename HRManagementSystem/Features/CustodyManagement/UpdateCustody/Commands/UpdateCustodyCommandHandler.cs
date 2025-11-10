using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CustodyManagement.UpdateCustody.Commands
{
    public sealed class UpdateCustodyCommandHandler : RequestHandlerBase<UpdateCustodyCommand, RequestResult<bool>, Custody, int>
    {
    
        private readonly IGeneralRepository<Employee, Guid> _employeeRepo;

        public UpdateCustodyCommandHandler(
            RequestHandlerBaseParameters<Custody, int> parameters,
            IGeneralRepository<Employee, Guid> employeeRepo
           )
            : base(parameters)
        {
            _employeeRepo = employeeRepo;
          
        }

        public override async Task<RequestResult<bool>> Handle(UpdateCustodyCommand request, CancellationToken ct)
        {
            // 1. جلب الكيان مع التتبع
            var custody = await _generalRepo.GetByIdWithTracking(request.Id);

            if (custody is null || custody.IsDeleted)
           
                return RequestResult<bool>.Failure("العهدة غير موجودة.", ErrorCode.NotFound);

            
            if (!string.IsNullOrWhiteSpace(request.SerialNumber) && request.SerialNumber != custody.SerialNumber)
            {
                var isSerialDuplicate = await _generalRepo.Get(
                    c => c.SerialNumber == request.SerialNumber && c.Id != request.Id && !c.IsDeleted,
                    ct
                )
                .AnyAsync(ct);

                if (isSerialDuplicate)
               
                    return RequestResult<bool>.Failure("الرقم التسلسلي الجديد مستخدم بالفعل لعهدة أخرى.", ErrorCode.Conflict);
            }

         
            if (request.EmployeeId.HasValue && request.EmployeeId.Value != custody.EmployeeId)
            {
                var employeeExists = await _employeeRepo.CheckAnyAsync(e => e.Id == request.EmployeeId.Value && !e.IsDeleted, ct);

                if (!employeeExists)
              
                    return RequestResult<bool>.Failure("الموظف الجديد المحدد غير موجود.", ErrorCode.NotFound);
            }

           
            custody.ItemName = request.ItemName ?? custody.ItemName;
            custody.SerialNumber = request.SerialNumber ?? custody.SerialNumber;
            custody.EmployeeId = request.EmployeeId ?? custody.EmployeeId;
            custody.HandoverDate = request.HandoverDate ?? custody.HandoverDate;
            custody.Status = request.Status ?? custody.Status;

            if (request.ReturnDate.HasValue && custody.ReturnDate == null)
            {
                custody.ReturnDate = request.ReturnDate.Value;
                custody.Status = "Returned";
            }

      
            await _generalRepo.UpdateAsync(custody, ct);


            return RequestResult<bool>.Success(true, "تم تحديث العهدة بنجاح.");
        }
    }
}

using AutoMapper.QueryableExtensions;
using HRManagementSystem.Features.Common.PayrollCommon;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.GetAllPayrollItems.Queries
{
    public sealed class GetAllPayrollItemsQueryHandler :
     RequestHandlerBase<GetAllPayrollItemsQuery, RequestResult<IEnumerable<PayrollItemDto>>, PayrollItem, int>
    {
       

        // نفترض أن IMapper يتم حقنه عبر RequestHandlerBaseParameters أو بشكل منفصل
        public GetAllPayrollItemsQueryHandler(
            RequestHandlerBaseParameters<PayrollItem, int> parameters)
            : base(parameters)
        {
      
        }

        public override async Task<RequestResult<IEnumerable<PayrollItemDto>>> Handle(GetAllPayrollItemsQuery request, CancellationToken ct)
        {
            
            var payrollItemDtos = await _generalRepo
                .Get(p => !p.IsDeleted, ct) 

       
                .OrderBy(x => x.Name)

         
                .ProjectTo<PayrollItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync(ct);

            if (!payrollItemDtos.Any())
            {
                return RequestResult<IEnumerable<PayrollItemDto>>.Success(
                    Enumerable.Empty<PayrollItemDto>(),
                    "لا توجد عناصر مرتب متاحة حاليًا.");
            }

            return RequestResult<IEnumerable<PayrollItemDto>>.Success(payrollItemDtos, "تم جلب جميع عناصر المرتب بنجاح.");
        }
    }
}

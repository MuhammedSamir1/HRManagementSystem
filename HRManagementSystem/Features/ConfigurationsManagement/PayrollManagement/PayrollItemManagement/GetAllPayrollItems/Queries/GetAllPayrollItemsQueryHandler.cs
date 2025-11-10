using AutoMapper.QueryableExtensions;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.GetAllPayrollItems.Queries
{
    public sealed class GetAllPayrollItemsQueryHandler :
     RequestHandlerBase<GetAllPayrollItemsQuery, RequestResult<IEnumerable<PayrollItemDto>>, PayrollItem, int>
    {


        // ????? ?? IMapper ??? ???? ??? RequestHandlerBaseParameters ?? ???? ?????
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
                    "?? ???? ????? ???? ????? ??????.");
            }

            return RequestResult<IEnumerable<PayrollItemDto>>.Success(payrollItemDtos, "?? ??? ???? ????? ?????? ?????.");
        }
    }
}

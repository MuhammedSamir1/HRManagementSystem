using FluentValidation;
using HRManagementSystem.Features.Common.CustodyCommon.Dtos;

namespace HRManagementSystem.Features.CustodyManagement.GetCustodyById.Queries
{
    public sealed record GetCustodyByIdQuery(int Id) : IRequest<RequestResult<ViewCustodyDto>>;
    public class GetCustodyByIdQueryValidator : AbstractValidator<GetCustodyByIdQuery>
    {
        public GetCustodyByIdQueryValidator()
        {

            RuleFor(x => x.Id).GreaterThan(0).WithMessage("رقم العهدة غير صالح للجلب.");
        }
    }
}

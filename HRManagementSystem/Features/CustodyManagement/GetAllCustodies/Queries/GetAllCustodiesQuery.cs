using FluentValidation;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.Common.CustodyCommon.Dtos;

namespace HRManagementSystem.Features.CustodyManagement.GetAllCustodies.Queries
{
    public sealed record GetAllCustodiesQuery(
      int PageNumber,
      int PageSize,
      string? SearchTerm,
      Guid? EmployeeId,
      string? Status) : IRequest<RequestResult<PagedList<ViewCustodyDto>>>;
    public class GetAllCustodiesQueryValidator : AbstractValidator<GetAllCustodiesQuery>
    {
        public GetAllCustodiesQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1).WithMessage("رقم الصفحة يجب أن يكون أكبر من أو يساوي 1.");
            RuleFor(x => x.PageSize).InclusiveBetween(5, 100).WithMessage("يجب أن يتراوح حجم الصفحة بين 5 و 100.");

            // التحقق من صلاحية Guid إذا تم إرساله
            RuleFor(x => x.EmployeeId)
                .NotEqual(Guid.Empty).When(x => x.EmployeeId.HasValue).WithMessage("معرف الموظف غير صالح.");
        }
    }
}

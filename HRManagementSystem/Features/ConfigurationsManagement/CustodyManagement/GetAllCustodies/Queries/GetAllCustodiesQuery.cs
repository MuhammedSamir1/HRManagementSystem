using FluentValidation;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.Common.CustodyCommon.Dtos;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetAllCustodies.Queries
{
    public sealed record GetAllCustodiesQuery(
      int PageNumber,
      int PageSize,
      string? SearchTerm,
      int? EmployeeId,
      string? Status) : IRequest<RequestResult<PagedList<ViewCustodyDto>>>;
    public class GetAllCustodiesQueryValidator : AbstractValidator<GetAllCustodiesQuery>
    {
        public GetAllCustodiesQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1).WithMessage("??? ?????? ??? ?? ???? ???? ?? ?? ????? 1.");
            RuleFor(x => x.PageSize).InclusiveBetween(5, 100).WithMessage("??? ?? ?????? ??? ?????? ??? 5 ? 100.");

            // ?????? ?? ?????? EmployeeId ??? ?? ??????
            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).When(x => x.EmployeeId.HasValue).WithMessage("???? ?????? ??? ????.");
        }
    }
}

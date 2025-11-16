using FluentValidation;
using HRManagementSystem.Features.Common.CustodyCommon.Dtos;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetCustodyById.Queries
{
    public sealed record GetCustodyByIdQuery(Guid Id) : IRequest<RequestResult<ViewCustodyDto>>;
    public class GetCustodyByIdQueryValidator : AbstractValidator<GetCustodyByIdQuery>
    {
        public GetCustodyByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("??? ?????? ??? ???? ?????.")
                .NotEqual(Guid.Empty).WithMessage("??? ?????? ??? ???? ?????.");
        }
    }
}


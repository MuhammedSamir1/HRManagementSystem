using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetSalaryItemById.Queries
{
    public sealed record GetSalaryItemByIdQuery(Guid Id) : IRequest<RequestResult<ViewSalaryItemByIdDto>>;

    public class GetSalaryItemByIdQueryHandler : RequestHandlerBase<GetSalaryItemByIdQuery, RequestResult<ViewSalaryItemByIdDto>, SalaryItem, Guid>
    {
        public GetSalaryItemByIdQueryHandler(RequestHandlerBaseParameters<SalaryItem, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<ViewSalaryItemByIdDto>> Handle(GetSalaryItemByIdQuery request, CancellationToken ct)
        {
            var salaryItem = await _generalRepo.GetByIdAsync(request.Id);

            if (salaryItem == null || salaryItem.IsDeleted)
                return RequestResult<ViewSalaryItemByIdDto>.Failure("Salary Item not found.", ErrorCode.NotFound);

            var mapped = _mapper.Map<ViewSalaryItemByIdDto>(salaryItem);
            return RequestResult<ViewSalaryItemByIdDto>.Success(mapped);
        }
    }
}


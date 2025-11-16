using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetLoanById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetLoanById
{
    [ApiGroup("Configurations Management", "Loan Management")]
    public class GetLoanByIdEndPoint : BaseEndPoint<GetLoanByIdViewModel, ResponseViewModel<ViewLoanByIdViewModel>>
    {
        public GetLoanByIdEndPoint(EndPointBaseParameters<GetLoanByIdViewModel> parameters) : base(parameters) { }

        [HttpGet("{id:int}")]
        public async Task<ResponseViewModel<ViewLoanByIdViewModel>> GetLoanById(Guid id, CancellationToken ct)
        {
            var query = new GetLoanByIdQuery(id);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewLoanByIdViewModel>.Failure(result.message, result.errorCode);
            }

            var mapped = _mapper.Map<ViewLoanByIdViewModel>(result.data);

            return ResponseViewModel<ViewLoanByIdViewModel>.Success(mapped);
        }
    }
}





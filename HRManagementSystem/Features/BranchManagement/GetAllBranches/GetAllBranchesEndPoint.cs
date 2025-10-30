using HRManagementSystem.Features.BranchManagement.GetAllBranches.Queries;

namespace HRManagementSystem.Features.BranchManagement.GetAllBranches
{
    public class GetAllBranchesEndPoint : BaseEndPoint<GetAllBranchesViewModel,
         ResponseViewModel<List<ViewBranchViewModel>>>
    {
        public GetAllBranchesEndPoint(EndPointBaseParameters<GetAllBranchesViewModel> parameters)
            : base(parameters) { }

        [HttpGet]
        public async Task<ResponseViewModel<List<ViewBranchViewModel>>> GetAll()
        {
            var org = await _mediator.Send(new GetAllBranchesQuery());

            if (!org.isSuccess) return ResponseViewModel<List<ViewBranchViewModel>>.Failure(org.message,
                ErrorCode.NoBranchesFound);

            var vm = _mapper.Map<List<ViewBranchViewModel>>(org.data);
            return ResponseViewModel<List<ViewBranchViewModel>>.Success(vm);
        }
    }
}

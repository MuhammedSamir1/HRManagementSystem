namespace HRManagementSystem.Features.DepartmentManagement.AddDepartment.Commands
{
    public record AddDepartmentCommand(
                                   int branchId, string name,
                                   string code, string? description)
                                   : IRequest<RequestResult<bool>>;

    public sealed class AddDepartmentCommandHandler : RequestHandlerBase<AddDepartmentCommand, RequestResult<bool>, Department, int>
    {
        public AddDepartmentCommandHandler(RequestHandlerBaseParameters<Department, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AddDepartmentCommand request, CancellationToken ct)
        {
            var branchValidation = await _mediator.Send(new IsBranchValidQuery(request.branchId), ct);
            if (!branchValidation.isSuccess)
            {
                //   Branch (NotFound) 
                return RequestResult<bool>.Failure(branchValidation.message , branchValidation.errorCode);
            }

            // 2.   عدم التكرار (Code) 
            var uniqueValidation = await _mediator.Send(new IsDepartmentCodeUniqueQuery(request.branchId, request.code), ct);
            if (!uniqueValidation.isSuccess)
            {
                
                return RequestResult<bool>.Failure(uniqueValidation.message, uniqueValidation.errorCode);
            }
            var department = _mapper.Map<Department>(request);

            var isAdded = await _generalRepo.AddAsync(department, ct);

            if (!isAdded) return RequestResult<bool>.Failure("Department wasn't added successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isAdded, "Department added successfully!");
        }
    }
}

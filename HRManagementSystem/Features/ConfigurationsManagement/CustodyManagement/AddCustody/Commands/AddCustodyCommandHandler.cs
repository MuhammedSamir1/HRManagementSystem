using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.AddCustody.Commands
{
    public sealed class AddCustodyCommandHandler : RequestHandlerBase<AddCustodyCommand, RequestResult<int>, Custody, int>
    {
        private readonly IGeneralRepository<Employee, int> _employeeRepo;

        public AddCustodyCommandHandler(
            RequestHandlerBaseParameters<Custody, int> parameters,
            IGeneralRepository<Employee, int> employeeRepo)
            : base(parameters)
        {
            _employeeRepo = employeeRepo;
        }

        public override async Task<RequestResult<int>> Handle(AddCustodyCommand request, CancellationToken ct)
        {
            // 1
            var employeeExists = await _employeeRepo.Get(e => e.Id == request.EmployeeId && !e.IsDeleted, ct)
                                                    .AnyAsync(ct);

            if (!employeeExists)
            {
                return RequestResult<int>.Failure($"Employee with ID {request.EmployeeId} not found or is inactive.", ErrorCode.NotFound);
            }

            // 2. ?????? ?? ????? ????????
            var isSerialDuplicate = await _generalRepo.Get(c => c.SerialNumber == request.SerialNumber && !c.IsDeleted, ct)
                                                     .AnyAsync(ct);

            if (isSerialDuplicate)
            {
                return RequestResult<int>.Failure($"Custody with Serial Number '{request.SerialNumber}' already exists.", ErrorCode.Conflict);
            }


            var newCustody = _mapper.Map<Custody>(request);
            newCustody.Status = "Active";


            var isAdded = await _generalRepo.AddAsync(newCustody, ct);

            if (!isAdded)
            {
                return RequestResult<int>.Failure("Failed to add Custody item.", ErrorCode.InternalServerError);
            }

            // 4. ????? ????????
            //var isSaved = await _generalRepo.(ct);

            //if (!isSaved)
            //{
            //    return RequestResult<int>.Failure("Failed to save the new Custody item to the database.", ErrorCode.InternalServerError);
            //}

            return RequestResult<int>.Success(newCustody.Id, "Custody item added successfully!");
        }
    }
}

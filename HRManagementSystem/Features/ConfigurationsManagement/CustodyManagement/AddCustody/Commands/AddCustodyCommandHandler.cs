using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.AddCustody.Commands
{
    public sealed class AddCustodyCommandHandler : RequestHandlerBase<AddCustodyCommand, RequestResult<Guid>, Custody, Guid>
    {
        public AddCustodyCommandHandler(
            RequestHandlerBaseParameters<Custody, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<Guid>> Handle(AddCustodyCommand request, CancellationToken ct)
        {
            // 1. ?????? ?? ????? ????????
            var isSerialDuplicate = await _generalRepo.Get(c => c.SerialNumber == request.SerialNumber && !c.IsDeleted, ct)
                                                     .AnyAsync(ct);

            if (isSerialDuplicate)
            {
                return RequestResult<Guid>.Failure($"Custody with Serial Number '{request.SerialNumber}' already exists.", ErrorCode.Conflict);
            }


            var newCustody = _mapper.Map<Custody>(request);
            newCustody.Status = "Active";


            var isAdded = await _generalRepo.AddAsync(newCustody, ct);

            if (!isAdded)
            {
                return RequestResult<Guid>.Failure("Failed to add Custody item.", ErrorCode.InternalServerError);
            }

            // 3. ????? ????????
            //var isSaved = await _generalRepo.(ct);

            //if (!isSaved)
            //{
            //    return RequestResult<Guid>.Failure("Failed to save the new Custody item to the database.", ErrorCode.InternalServerError);
            //}

            return RequestResult<Guid>.Success(newCustody.Id, "Custody item added successfully!");
        }
    }
}


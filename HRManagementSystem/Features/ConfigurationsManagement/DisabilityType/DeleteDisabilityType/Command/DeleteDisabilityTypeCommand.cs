namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.DeleteDisabilityType.Command
{
    public sealed record DeleteDisabilityTypeCommand(Guid Id) : IRequest<RequestResult<bool>>;

    // Commands/DeleteDisabilityType/DeleteDisabilityTypeCommandHandler.cs
    public sealed class DeleteDisabilityTypeCommandHandler
        : RequestHandlerBase<DeleteDisabilityTypeCommand, RequestResult<bool>,
          Data.Models.ConfigurationsModels.DisabilityType, Guid>
    {
        public DeleteDisabilityTypeCommandHandler(
            RequestHandlerBaseParameters<Data.Models.ConfigurationsModels.DisabilityType, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(
            DeleteDisabilityTypeCommand request, CancellationToken ct)
        {
            // Check if disability type exists
            var existingDisabilityType = await _generalRepo.GetByIdAsync(request.Id);
            if (existingDisabilityType == null || existingDisabilityType.IsDeleted)
            {
                return RequestResult<bool>.Failure(
                    "Disability type not found with this id", ErrorCode.NotFound);
            }

            #region Check if disability type is being used by any employees (int the future)
            // 
            //var isInUse = await _mediator.Send(
            //    new IsDisabilityTypeInUseQuery(request.Id), ct);

            //if (!isInUse.isSuccess)
            //{
            //    return RequestResult<bool>.Failure(
            //        "Cannot delete disability type. It is being used by one or more employees.",
            //        ErrorCode.ConstraintViolation);
            //} 
            #endregion

            // Soft delete the disability type
            await _generalRepo.SoftDeleteAsync(request.Id, ct);

            return RequestResult<bool>.Success(true, "Disability type deleted successfully");
        }
    }
}


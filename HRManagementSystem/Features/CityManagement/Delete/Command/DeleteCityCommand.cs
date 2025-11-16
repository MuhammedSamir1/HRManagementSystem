using HRManagementSystem.Data.Models.AddressEntity;

namespace HRManagementSystem.Features.CityManagement.Delete.Command
{
    public sealed record DeleteCityCommand(Guid Id) : IRequest<RequestResult<bool>>;

    public sealed class DeleteCityCommandHandler
        : RequestHandlerBase<DeleteCityCommand, RequestResult<bool>, City, Guid>
    {
        public DeleteCityCommandHandler(RequestHandlerBaseParameters<City, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(DeleteCityCommand request, CancellationToken ct)
        {
            // ? Soft Delete using Repository method
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, ct);

            // ? If delete failed (not found or already deleted)
            if (!isDeleted)
                return RequestResult<bool>.Failure("City not found or already deleted.", ErrorCode.NotFound);

            // ? Success response
            return RequestResult<bool>.Success(true, "City deleted successfully!");
        }
    }
}


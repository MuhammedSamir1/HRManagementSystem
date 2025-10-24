using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CountryManagement.UpdateCountry.Commands
{
    public sealed class UpdateCountryCommandHandler : RequestHandlerBase<UpdateCountryCommand, ResponseViewModel<ViewCountryDto>, Country, int>
    {
        public UpdateCountryCommandHandler(RequestHandlerBaseParameters<Country, int> parameters) : base(parameters)
        {
        }

        public override async Task<ResponseViewModel<ViewCountryDto>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {

            var countryEntity = await _generalRepo.GetByIdWithTracking(request.Id);

            if (countryEntity == null)
            {
                return ResponseViewModel<ViewCountryDto>.Failure(ErrorCode.NotFound);
            }

            // 
            var exists = await _generalRepo.Get(c => c.Iso3 == request.Iso3 && c.Id != request.Id, cancellationToken).AnyAsync(cancellationToken);
            if (exists)
            {
                return ResponseViewModel<ViewCountryDto>.Failure(ErrorCode.Conflict);
            }

            // 3
            _mapper.Map(request, countryEntity);
            await _generalRepo.UpdateAsync(countryEntity, cancellationToken);

            var countryDto = _mapper.Map<ViewCountryDto>(countryEntity);
            return ResponseViewModel<ViewCountryDto>.Success(countryDto, "Country updated successfully.");
        }
    }
}

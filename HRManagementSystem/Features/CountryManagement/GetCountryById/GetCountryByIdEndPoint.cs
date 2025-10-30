﻿using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;

namespace HRManagementSystem.Features.CountryManagement.GetCountryById
{
    public class GetCountryByIdEndPoint : BaseEndPoint<int, ViewCountryDto>
    {
        public GetCountryByIdEndPoint(EndPointBaseParameters<int> parameters) : base(parameters) { }

        [HttpGet("{id:int}")] // GET api/country/getcountrybyid/5
        public async Task<ResponseViewModel<ViewCountryDto>> GetCountryById([FromRoute] int id, CancellationToken ct)
        {

            var result = await _mediator.Send(new GetCountryByIdQuery(id), ct);

            if (!result.isSuccess) return ResponseViewModel<ViewCountryDto>.Failure(result.errorCode);
            return ResponseViewModel<ViewCountryDto>.Success(result.data);
        }
    }
}

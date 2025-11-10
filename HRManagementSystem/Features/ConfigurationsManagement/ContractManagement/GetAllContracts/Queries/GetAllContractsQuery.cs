using AutoMapper.QueryableExtensions;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetAllContracts.Queries
{
    public record GetAllContractsQuery() : IRequest<RequestResult<IEnumerable<GetAllContractsDto>>>;

    public class GetAllContractsQueryHandler : RequestHandlerBase<GetAllContractsQuery, RequestResult<IEnumerable<GetAllContractsDto>>, Contract, int>
    {
        public GetAllContractsQueryHandler(RequestHandlerBaseParameters<Contract, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<IEnumerable<GetAllContractsDto>>> Handle(GetAllContractsQuery request, CancellationToken ct)
        {
            var contracts = await _generalRepo.Get(x => !x.IsDeleted, ct)
               .ProjectTo<GetAllContractsDto>(_mapper.ConfigurationProvider)
               .ToListAsync(ct);

            if (contracts is null)
                return RequestResult<IEnumerable<GetAllContractsDto>>.Failure("No contracts found.", ErrorCode.NotFound);

            return RequestResult<IEnumerable<GetAllContractsDto>>.Success(contracts, "Contracts retrieved successfully!");
        }
    }
}


using ProfilesService.Domain.Model.Aggregates;
using ProfilesService.Domain.Model.Queries.Provider;
using ProfilesService.Domain.Repositories;
using ProfilesService.Domain.Services.Provider;

namespace ProfilesService.Application.Internal.QueryService;

public class ProviderQueryService(IProviderRepository providerRepository) : IProviderQueryService
{
    public async Task<IEnumerable<Provider>> Handle(GetAllProvidersQuery query) => await providerRepository.FindProviderByHotelIdAsync(query.HotelId);
    
}
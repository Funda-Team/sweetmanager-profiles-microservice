using ProfilesService.Domain.Model.Queries.Provider;

namespace ProfilesService.Domain.Services.Provider;

public interface IProviderQueryService
{
    Task<IEnumerable<Model.Aggregates.Provider>> Handle(GetAllProvidersQuery query);
}
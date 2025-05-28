using ProfilesService.Domain.Model.Aggregates;
using ProfilesService.Domain.Model.ValueObject;
using ProfilesService.Shared.Domain.Repositories;

namespace ProfilesService.Domain.Repositories;

public interface IProviderRepository : IBaseRepository<Provider>
{
    Task<bool> UpdateProviderStateAsync(int id,string address, string email, int phone, StateType state);
    
    Task<IEnumerable<Provider>> FindProviderByHotelIdAsync(int hotelId);

}
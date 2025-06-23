using ProfilesService.Domain.Model.Aggregates;

namespace ProfilesService.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<IEnumerable<Customer>> FetchCustomersByHotelId(int hotelId);
}
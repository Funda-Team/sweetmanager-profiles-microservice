using ProfilesService.Domain.Model.Aggregates;
using ProfilesService.Domain.Model.Queries;
using ProfilesService.Domain.Services.Customer;

namespace ProfilesService.Interfaces.ACL.Services;

public class ProfilesContextFacade(ICustomerQueryService customerQueryService) : IProfilesContextFacade
{
    public async Task<IEnumerable<Customer>> FetchCustomersByHotelId(int hotelId)=>
    await customerQueryService.Handle(new GetAllCustomersQuery(hotelId));
}
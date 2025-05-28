using ProfilesService.Domain.Model.Aggregates;
using ProfilesService.Domain.Model.Queries;
using ProfilesService.Domain.Repositories;
using ProfilesService.Domain.Services.Customer;

namespace ProfilesService.Application.Internal.QueryService
{
    public class CustomerQueryService (ICustomerRepository customerRepository) : ICustomerQueryService
    {
        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query) => await customerRepository.FindCustomerByHotelIdAsync(query.HotelId);
    
    
    }
}
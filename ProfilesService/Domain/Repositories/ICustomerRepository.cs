using ProfilesService.Domain.Model.Aggregates;
using ProfilesService.Domain.Model.ValueObject;
using ProfilesService.Shared.Domain.Repositories;

namespace ProfilesService.Domain.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    Task<bool> UpdateCustomerStateAsync(int id, string email, int phone, StateType state);
    
    Task<IEnumerable<Customer>> FindCustomerByHotelIdAsync(int hotelId);
    
    Task<bool> EmailExistsAsync(string email);
    
    Task<bool> UsernameExistsAsync(string username);
}
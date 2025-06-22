using Microsoft.EntityFrameworkCore;
using ProfilesService.Domain.Model.Aggregates;
using ProfilesService.Domain.Model.ValueObject;
using ProfilesService.Domain.Repositories;
using ProfilesService.Shared.Infrastructure.Persistence.EFC.Configuration;
using ProfilesService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ProfilesService.Infrastructure.Persistence.EFC.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    private readonly ProfilesContext _context;
    
    public CustomerRepository(ProfilesContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<bool> UpdateCustomerStateAsync(int id, string email, int phone, StateType state) =>
        await _context.Set<Customer>()
            .Where(c =>c.Id == id)
            .ExecuteUpdateAsync( c =>c
                .SetProperty(u => u.Email, email)
                .SetProperty(u => u.Phone, phone)
                .SetProperty(u => u.State, state)
            ) > 0;

    public async Task<IEnumerable<Customer>> FindCustomerByHotelIdAsync(int hotelId)
    {
        return await Context.Set<Customer>().Where(c => c.HotelsId.Equals(hotelId)).ToListAsync();
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        var exists = _context.Set<Customer>()
            .AnyAsync(c => c.Email == email);
        return await exists;
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        var exists = _context.Set<Customer>()
            .AnyAsync(c => c.Username == username);
        return await exists;
    }
}
using Microsoft.EntityFrameworkCore;
using ProfilesService.Domain.Model.Aggregates;
using ProfilesService.Domain.Model.ValueObject;
using ProfilesService.Domain.Repositories;
using ProfilesService.Shared.Infrastructure.Persistence.EFC.Configuration;
using ProfilesService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ProfilesService.Infrastructure.Persistence.EFC.Repositories;

public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
{
    private readonly ProfilesContext _context;
    
    public ProviderRepository(ProfilesContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<bool> UpdateProviderStateAsync(int id, string address, string email, int phone, StateType state)=>
        await _context.Set<Provider>()
            .Where(c=>c.Id == id )
            .ExecuteUpdateAsync(c => c
                .SetProperty(u => u.Address, address)
                .SetProperty(u => u.Email, email)
                .SetProperty(u => u.Phone, phone)
                .SetProperty(u => u.State, state)
            ) > 0;
    public async Task<IEnumerable<Provider>> FindProviderByHotelIdAsync(int hotelId)
    {
        return await _context.Set<Provider>()
            .Where(p => p.HotelsId.Equals(hotelId))
            .ToListAsync();
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        var exists = _context.Set<Provider>()
            .AnyAsync(p => p.Email == email);
        return await exists;
    }

    public Task<bool> NameExistsAsync(string name)
    {
        var exists = _context.Set<Provider>()
            .AnyAsync(p => p.Name == name);
        return exists;
    }
}
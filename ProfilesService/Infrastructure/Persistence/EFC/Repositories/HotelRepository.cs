using Microsoft.EntityFrameworkCore;
using ProfilesService.Domain.Model.Entities;
using ProfilesService.Domain.Repositories;
using ProfilesService.Shared.Infrastructure.Persistence.EFC.Configuration;
using ProfilesService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ProfilesService.Infrastructure.Persistence.EFC.Repositories;

public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
{
    private readonly ProfilesContext _context;

    public HotelRepository(ProfilesContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Hotel>> GetAllAsync()
    {
        return await _context.Set<Hotel>().ToListAsync();
    }

    public async Task<Hotel?> GetByOwnersIdAsync(int ownerId)
    {
        return await _context.Set<Hotel>().FirstOrDefaultAsync(tr=> tr.OwnersId == ownerId);
    }

    public async Task<bool> UpdateHotelStateAsync(int id, string name, int phone, string email)
    {
        var result = await _context.Set<Hotel>()
            .Where(h => h.Id == id)  
            .ExecuteUpdateAsync(h => h
                .SetProperty(u => u.Name, name)    
                .SetProperty(u => u.Phone, phone)  
                .SetProperty(u => u.Email, email)  
            );

        return result > 0;
    }
}
using ProfilesService.Domain.Model.Entities;
using ProfilesService.Shared.Domain.Repositories;

namespace ProfilesService.Domain.Repositories;

public interface IHotelRepository : IBaseRepository<Hotel>
{
    Task<IEnumerable<Hotel>> GetAllAsync();
    
    Task<Hotel?> GetByOwnersIdAsync(int ownerId);

    Task<bool> UpdateHotelStateAsync(int id,string name, int phone, string email);

}
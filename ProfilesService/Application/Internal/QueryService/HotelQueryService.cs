using ProfilesService.Domain.Model.Entities;
using ProfilesService.Domain.Model.Queries.Hotel;
using ProfilesService.Domain.Repositories;
using ProfilesService.Domain.Services.Hotel;

namespace ProfilesService.Application.Internal.QueryService;

public class HotelQueryService: IHotelQueryService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelQueryService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }
    public async Task<IEnumerable<Hotel>> handle(GetAllHotelsQuery query)
    {
        return await _hotelRepository.GetAllAsync();
    }

    public async Task<Hotel?> handle(GetHotelByOwnersIdQuery query)
    {
        return await _hotelRepository.GetByOwnersIdAsync(query.OwnerId);
    }
}
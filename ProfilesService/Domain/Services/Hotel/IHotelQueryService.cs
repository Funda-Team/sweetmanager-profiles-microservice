using ProfilesService.Domain.Model.Queries.Hotel;

namespace ProfilesService.Domain.Services.Hotel;

public interface IHotelQueryService
{
    Task<IEnumerable<Model.Entities.Hotel>> handle(GetAllHotelsQuery query);
    Task<Model.Entities.Hotel?> handle(GetHotelByOwnersIdQuery query);
}
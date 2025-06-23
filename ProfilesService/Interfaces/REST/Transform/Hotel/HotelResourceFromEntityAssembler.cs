using ProfilesService.Interfaces.REST.Resources.Hotel;

namespace ProfilesService.Interfaces.REST.Transform.Hotel;

public class HotelResourceFromEntityAssembler
{
    public static HotelResource ToResourceFromEntity(Domain.Model.Entities.Hotel entity) =>
        new(entity.Id, entity.OwnersId, entity.Name, entity.Description, entity.Address,entity.Phone,entity.Email);
}
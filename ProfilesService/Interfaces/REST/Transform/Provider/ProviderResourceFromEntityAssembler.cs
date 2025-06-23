using ProfilesService.Interfaces.REST.Resources.Provider;

namespace ProfilesService.Interfaces.REST.Transform.Provider;

public class ProviderResourceFromEntityAssembler
{
    public static ProviderResource ToResourceFromEntity(Domain.Model.Aggregates.Provider entity) =>
        new(entity.Id, entity.Name, entity.Address, entity.Email, entity.Phone, entity.State,entity.HotelsId);
}
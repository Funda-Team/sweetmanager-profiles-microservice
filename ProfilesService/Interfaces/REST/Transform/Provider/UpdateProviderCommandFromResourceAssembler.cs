using ProfilesService.Domain.Model.Commands.Provider;
using ProfilesService.Interfaces.REST.Resources.Provider;

namespace ProfilesService.Interfaces.REST.Transform.Provider;

public class UpdateProviderCommandFromResourceAssembler
{
    public static UpdateProviderCommand ToCommandFromResource(int id, UpdateProviderResource resource) => 
    new(id,resource.Address,resource.Email,resource.Phone,resource.State);
}

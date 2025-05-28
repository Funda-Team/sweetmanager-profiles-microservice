using ProfilesService.Domain.Model.Commands.Provider;
using ProfilesService.Interfaces.REST.Resources.Provider;

namespace ProfilesService.Interfaces.REST.Transform.Provider;

public class UpdateProviderCommandFromResourceAssembler
{
    public static UpdateProviderCommand ToCommandFromResource(UpdateProviderResource resource) => 
    new(resource.Id,resource.Address,resource.Email,resource.Phone,resource.State);
}

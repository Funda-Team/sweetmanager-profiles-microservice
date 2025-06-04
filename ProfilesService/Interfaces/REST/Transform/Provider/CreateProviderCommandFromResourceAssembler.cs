using ProfilesService.Domain.Model.Commands.Provider;
using ProfilesService.Interfaces.REST.Resources.Provider;

namespace ProfilesService.Interfaces.REST.Transform.Provider;

public class CreateProviderCommandFromResourceAssembler
{
    public static CreateProviderCommand ToCommandFromResource(CreateProviderResource resource) =>
    new(resource.Name,resource.Address,resource.Email,resource.Phone,resource.HotelId);
}
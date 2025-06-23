using ProfilesService.Domain.Model.Commands.Hotel;
using ProfilesService.Interfaces.REST.Resources.Hotel;

namespace ProfilesService.Interfaces.REST.Transform.Hotel;

public class CreateHotelCommandFromResourceAssembler
{
    public static CreateHotelCommand ToCommandFromResource(CreateHotelResource resource)=>
    new(resource.OwnersId,resource.Name,resource.Description,resource.Address,resource.Phone,resource.Email);
}
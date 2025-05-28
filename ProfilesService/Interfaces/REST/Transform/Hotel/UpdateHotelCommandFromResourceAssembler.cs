using ProfilesService.Domain.Model.Commands.Hotel;
using ProfilesService.Interfaces.REST.Resources.Hotel;

namespace ProfilesService.Interfaces.REST.Transform.Hotel;

public class UpdateHotelCommandFromResourceAssembler
{
    public static UpdateHotelCommand ToCommandFromResource(UpdateHotelResource resource)=>
    new(resource.Id,resource.Name,resource.Phone,resource.Email);
}